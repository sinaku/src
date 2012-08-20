using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// テーブルのモデルを管理します
    /// </summary>
    public class TableModel
    {
        /// <summary>
        /// 論理名
        /// </summary>
        public string LogicalName { get; private set; }

        /// <summary>
        /// 物理名
        /// </summary>
        public string PhysicalName { get; private set; }

        /// <summary>
        /// テーブルのカラムモデルリスト
        /// </summary>
        private List<ColumnModel> _columnModels;

        /// <summary>
        /// テーブルのカラムモデル読み取り専用IList
        /// </summary>
        /// <remarks>
        /// 格納されているデータの変更はできません。戻す値は、List.AsReadOnlyを使用して生成した、
        /// 読み取り専用のIListのラッパークラスになります。
        /// </remarks>
        public IList<ColumnModel> ColumnModels
        {
            get
            {
                return this._columnModels.AsReadOnly();
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logicalName">論理名</param>
        /// <param name="physicalName">物理名</param>
        /// <param name="columnModels">カラムモデルリスト</param>
        public TableModel(string logicalName, string physicalName, List<ColumnModel> columnModels)
        {
            this.LogicalName = logicalName;
            this.PhysicalName = physicalName;
            this._columnModels = columnModels;
        }
    }
}
