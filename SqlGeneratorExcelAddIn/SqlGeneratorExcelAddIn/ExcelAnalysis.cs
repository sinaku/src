using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Text.RegularExpressions;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// エクセルの解析用クラスです
    /// </summary>
    public class ExcelAnalysis
    {
        /// <summary>
        /// 入力されたExcelアドレスの妥当性を確認する為の正規表現
        /// </summary>
        private static readonly Regex ___excelAddress =
            new Regex(@"^[A-Z]{1,3}[1-9]{1}[0-9]{0,4}$", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
        /// <summary>
        /// ExcelのX方向への座標取得用
        /// </summary>
        private static readonly Regex ___excelAddressXIndex =
            new Regex(@"^[A-Z]{1,3}", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
        /// <summary>
        /// ExcelのY方向への座標取得用
        /// </summary>
        private static readonly Regex ___excelAddressYIndex =
            new Regex(@"[1-9]{1}[0-9]{0,4}$", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);

        /// <summary>
        /// エクセルシート上に存在するEntityの論理名定義位置
        /// </summary>
        private readonly string _entityLogicalNameAddress;
        /// <summary>
        /// エクセルシート上に存在するEntityの物理名定義位置
        /// </summary>
        private readonly string _entityPhysicalNameAddress;


        /// <summary>
        /// 項目読込開始行
        /// </summary>
        private readonly int _readStartRowIndex;
        /// <summary>
        /// 項目論理名称格納カラム位置
        /// </summary>
        private readonly int _itemLogicalNameColumn;
        /// <summary>
        /// 項目物理名称格納カラム位置
        /// </summary>
        private readonly int _itemPhysicalNameColumn;
        /// <summary>
        /// 項目データタイプ格納カラム位置
        /// </summary>
        private readonly int _dataTypeNameColumn;
        /// <summary>
        /// 項目桁数格納カラム位置
        /// </summary>
        private readonly int _precisionColumn;
        /// <summary>
        /// 項目小数点以下桁数格納カラム位置
        /// </summary>
        private readonly int _scaleColumn;
        /// <summary>
        /// 項目Key定義格納カラム位置
        /// </summary>
        private readonly int _isKeyColumn;
        /// <summary>
        /// 項目null許容定義格納カラム位置
        /// </summary>
        private readonly int _permitsNullColumn;
        /// <summary>
        /// 項目デフォルト値定義格納カラム位置
        /// </summary>
        private readonly int _defaultValueColumn;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="entityLogicalNameAddress">Entityの論理名定義位置</param>
        /// <param name="entityPhysicalNameAddress">Entityの物理名定義位置</param>
        /// <param name="readStartRowIndex">項目の読み取り開始行</param>
        /// <param name="itemLogicalNameColumn">項目論理名定義位置</param>
        /// <param name="itemPhysicalNameColumn">項目物理名定義位置</param>
        public ExcelAnalysis(
            string entityLogicalNameAddress,
            string entityPhysicalNameAddress,
            string readStartRowIndex,
            string itemLogicalNameColumn,
            string itemPhysicalNameColumn)
        {
            if (string.IsNullOrWhiteSpace(entityLogicalNameAddress) || string.IsNullOrWhiteSpace(entityPhysicalNameAddress)
                || string.IsNullOrWhiteSpace(itemLogicalNameColumn) || string.IsNullOrWhiteSpace(itemPhysicalNameColumn)
                || string.IsNullOrWhiteSpace(readStartRowIndex))
                throw new ArgumentException(@"Excelの座標指定が入力されていません。");

            if (!ExcelAnalysis.___excelAddress.IsMatch(entityLogicalNameAddress)
                || !ExcelAnalysis.___excelAddress.IsMatch(entityPhysicalNameAddress)
                || !ExcelAnalysis.___excelAddressYIndex.IsMatch(readStartRowIndex)
                || !ExcelAnalysis.___excelAddressXIndex.IsMatch(itemLogicalNameColumn)
                || !ExcelAnalysis.___excelAddressXIndex.IsMatch(itemPhysicalNameColumn))
            {
                throw new ArgumentException(@"Excelの座標指定が間違っています。");
            }

            this._entityLogicalNameAddress = entityLogicalNameAddress.ToUpper();
            this._entityPhysicalNameAddress = entityPhysicalNameAddress.ToUpper();
            
            if (!int.TryParse(readStartRowIndex, out this._readStartRowIndex))
                throw new ArgumentException(@"読込開始行を数値に変換できません。");

            this._itemLogicalNameColumn = this.XIndexToInt(itemLogicalNameColumn.ToUpper());
            this._itemPhysicalNameColumn = this.XIndexToInt(itemPhysicalNameColumn.ToUpper());
        }
        
        
        /// <summary>
        /// 現在開いているExcelの選択中シート全てのTableModelを生成します
        /// </summary>
        /// <returns>
        /// 生成されたTableModelのListが戻ります。
        /// </returns>
        /// <exception cref="FileFormatException">
        /// テーブル定義書が存在しない、又は、読み込めない形式の場合に発生するExceptionです。
        /// </exception>
        public List<TableModel> GetTableModels()
        {
            var tableModels = new List<TableModel>();

            foreach (var workSheet in SqlGeneratorExcelAddIn.Globals.ThisAddIn.Application.Windows.Application.ActiveWindow.SelectedSheets)
            {
                var tableModel = this.GetTableModel((Excel.Worksheet)workSheet);
                if (tableModels == null) continue;

                tableModels.Add(tableModel);
            }

            if (tableModels.Count == 0)
                throw new FileFormatException(@"テーブル定義書が存在しない、又は、読み込めないフォーマットです。");

            return tableModels;
        }


        /// <summary>
        /// 指定されたExcelのシート解析を行いTableModelを返します。
        /// </summary>
        /// <param name="workSheet">解析対象のエクセルシート</param>
        /// <returns>
        /// エクセルシートの解析により生成されたTableModelを返します。
        /// 選択されたシート内に有効なTableModel作成データが存在しない場合はnullが戻ります。
        /// </returns>
        private TableModel GetTableModel(Excel.Worksheet workSheet)
        {
            var entityLogicalName =
                this.GetCellValue(
                    workSheet,
                    ExcelAnalysis.___excelAddressXIndex.Match(this._entityLogicalNameAddress).Value.ToString(),
                    ExcelAnalysis.___excelAddressYIndex.Match(this._entityLogicalNameAddress).Value.ToString());

            var entityPhysicalName =
                this.GetCellValue(
                    workSheet,
                    ExcelAnalysis.___excelAddressXIndex.Match(this._entityPhysicalNameAddress).Value.ToString(),
                    ExcelAnalysis.___excelAddressYIndex.Match(this._entityPhysicalNameAddress).Value.ToString());

            return new TableModel(entityLogicalName, entityPhysicalName, this.GetColumnModels(workSheet));
        }


        /// <summary>
        /// 項目定義のリストを指定されたエクセルから生成します。
        /// </summary>
        /// <param name="workSheet">項目定義を作る元</param>
        /// <returns>取得結果(取得できなかった場合は、nullが戻ります)</returns>
        private List<ColumnModel> GetColumnModels(Excel.Worksheet workSheet)
        {
            var columnModels = new List<ColumnModel>();
            for (int rowIndex = this._readStartRowIndex; ; rowIndex++)
            {
                var columnModel = this.GetColumnModel(workSheet, rowIndex);
                if (columnModel == null)
                    break;

                columnModels.Add(columnModel);
            }

            return columnModels;
        }

        /// <summary>
        /// 指定された行から各項目値を取得します。
        /// </summary>
        /// <param name="workSheet">対象のエクセルシート</param>
        /// <param name="rowIndex">読み取り行</param>
        /// <returns>
        /// 取得できた場合は、ColumnModelが取得されます。
        /// ただし、最終行などで空行の場合はnullが戻ります。
        /// </returns>
        private ColumnModel GetColumnModel(Excel.Worksheet workSheet, int rowIndex)
        {
            var itemLogicalName = this.GetCellValue(workSheet, this._itemLogicalNameColumn, rowIndex);
            var itemPhysicalName = this.GetCellValue(workSheet, this._itemPhysicalNameColumn, rowIndex);

            if (string.IsNullOrWhiteSpace(itemLogicalName) || string.IsNullOrWhiteSpace(itemPhysicalName))
                return null;

            return new ColumnModel(itemLogicalName, itemPhysicalName);
        }

        /// <summary>
        /// 指定されたワークシート内の指定された座標の値を取得します。
        /// </summary>
        /// <param name="workSheet">対象のワークシート</param>
        /// <param name="xIndex">X座標(アルファベット)</param>
        /// <param name="yIndex">Y座標</param>
        /// <returns>値</returns>
        private string GetCellValue(Excel.Worksheet workSheet, string xIndex, string yIndex)
        {
            return this.GetCellValue(workSheet, this.XIndexToInt(xIndex), int.Parse(yIndex));
        }

        /// <summary>
        /// 指定されたワークシート内の指定された座標の値を取得します。
        /// </summary>
        /// <param name="workSheet">対象のワークシート</param>
        /// <param name="xIndex">X座標</param>
        /// <param name="yIndex">Y座標</param>
        /// <returns>値</returns>
        private string GetCellValue(Excel.Worksheet workSheet, int xIndex, int yIndex)
        {
            var cellData = (Excel.Range)workSheet.Cells[yIndex, xIndex];
            return (string)cellData.Value;
        }

        /// <summary>
        /// エクセルのX座標をアルファベットから数値に変換します
        /// </summary>
        /// <param name="xIndex">変換対象の座標</param>
        /// <returns>変換結果</returns>
        private int XIndexToInt(string xIndex)
        {
            var chars = xIndex.ToCharArray();
            // 26進数に対する累乗する為の指数。3桁なら26を2乗した値に対してさらに自分自身のA-Zに当たる数字を乗算したものが座標になる。
            int exponent = xIndex.Length - 1;
            int ret = 0;
            foreach (var c in chars)
            {
                ret += (((int)c) - 64) * (int)Math.Pow((double)26, (double)exponent);
                exponent -= 1;
            }

            if (ret < 1 || 16384 < ret)
                throw new ArgumentOutOfRangeException(@"指定されたエクセル列が0を指しているか、16384列の最大値をオーバーしています。");

            return ret;
        }
    }
}
