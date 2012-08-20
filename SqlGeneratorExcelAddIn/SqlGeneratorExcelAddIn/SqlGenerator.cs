using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// TableModelsをもとに、各種のSQL文を生成する為のクラスです。
    /// </summary>
    public class SqlGenerator
    {
        /// <summary>
        /// Select文生成時にAsを設定するか
        /// </summary>
        private bool AsSets { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="asSets">Select文生成時にAsを設定するか</param>
        public SqlGenerator(bool asSets)
        {
            this.AsSets = asSets;
        }

        /// <summary>
        /// 指定されたTableModelsを元にSelect文の生成を行います。
        /// </summary>
        /// <param name="tableModels">生成対象のTableModelのリスト</param>
        /// <returns>生成結果</returns>
        /// <exception cref="ArgumentNullException">
        /// tableModelsにnullのデータを引き渡した際に発生するExceptionです。
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// tableModelsに0件のデータを引き渡した際に発生するExceptionです。
        /// </exception>
        public List<OutputDataModel> GetSelectSqlList(List<TableModel> tableModels)
        {
            if (tableModels == null)
                throw new ArgumentNullException(@"指定されたTableModelのリストにNullが指定されています。");
            if (tableModels.Count == 0)
                throw new ArgumentOutOfRangeException(@"指定されたTableModelのリストが0件です。1件以上のデータが必要となります。");

            var sqlList = new List<OutputDataModel>();
            foreach (var tableModel in tableModels)
            {
                sqlList.Add(
                    new OutputDataModel(tableModel.LogicalName, tableModel.PhysicalName, this.GetSelectSql(tableModel)));
            }

            return sqlList;
        }

        /// <summary>
        /// 指定されたTableModelsを元にTableCreate文の生成を行います。
        /// </summary>
        /// <param name="tableModels">生成対象のTableModelのリスト</param>
        /// <returns>生成結果</returns>
        /// <exception cref="ArgumentNullException">
        /// tableModelsにnullのデータを引き渡した際に発生するExceptionです。
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// tableModelsに0件のデータを引き渡した際に発生するExceptionです。
        /// </exception>
        public List<string> GetCreateTableSqlList(List<TableModel> tableModels)
        {
            if (tableModels == null)
                throw new ArgumentNullException(@"指定されたTableModelのリストにNullが指定されています。");
            if (tableModels.Count == 0)
                throw new ArgumentOutOfRangeException(@"指定されたTableModelのリストが0件です。1件以上のデータが必要となります。");


            return new List<string>();
        }

        /// <summary>
        /// 指定されたTableModelをもとにSelect文を生成します。
        /// </summary>
        /// <param name="tableModel">Select文を生成する対象のTableModel</param>
        /// <returns>生成したSelect文</returns>
        private string GetSelectSql(TableModel tableModel)
        {
            if (tableModel == null)
                throw new ArgumentNullException(@"指定されたTableModelにNullが指定されています。");
            if (tableModel.ColumnModels == null)
                throw new ArgumentNullException(@"指定されたTableModelのColumnModelリストにNullが指定されています。");
            if (tableModel.ColumnModels.Count == 0)
                throw new ArgumentOutOfRangeException(@"指定されたTableModelのColumnModelリストが0件です。1件以上のデータが必要となります。");

            // 整形用の最大文字列長を格納しておきます。
            int maxLength = 0;
            foreach (var columnModel in tableModel.ColumnModels)
            {
                maxLength = columnModel.PhysicalName.Length <= maxLength ? maxLength : columnModel.PhysicalName.Length;
            }
            // スペース文のバッファーをカウントアップ
            maxLength += 1;

            // テーブル定義書に合わせて、Select文を生成
            var sb = new StringBuilder();
            sb.Append(@"SELECT ");
            foreach (var columnModel in tableModel.ColumnModels)
            {
                sb.Append(columnModel.PhysicalName.PadRight(maxLength));

                if (this.AsSets) sb.Append(@"AS ");

                sb.Append(@"""");
                sb.Append(columnModel.LogicalName);
                sb.Append(@"""");

                sb.Append(Environment.NewLine);
                sb.Append(@"      ,");
            }
            sb.Remove(sb.Length - 7, 7);

            sb.Append(@"  FROM ");
            sb.Append(tableModel.PhysicalName);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
        private string GetCreateSql(TableModel tableModel)
        {
            if (tableModel == null)
                throw new ArgumentNullException(@"指定されたTableModelにNullが指定されています。");
            if (tableModel.ColumnModels.Count == 0)
                throw new ArgumentOutOfRangeException(@"指定されたTableModelのColumnModelリストが0件です。1件以上のデータが必要となります。");


            return string.Empty;
        }

    }
}
