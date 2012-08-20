using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// 出力データを格納する為のクラスです。
    /// </summary>
    public class OutputDataModel
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
        /// 出力データ
        /// </summary>
        public string OutputData { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logicalName">論理名</param>
        /// <param name="physicalName">物理名</param>
        /// <param name="outputData">出力データ</param>
        public OutputDataModel(string logicalName, string physicalName, string outputData)
        {
            this.LogicalName = logicalName;
            this.PhysicalName = physicalName;
            this.OutputData = outputData;
        }
    }
}
