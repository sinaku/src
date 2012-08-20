using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// カラムの型を管理する為のクラスです。
    /// </summary>
    public class ColumnModel
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
        /// Key
        /// </summary>
        public bool IsKey { get; private set; }

        /// <summary>
        /// カラムの型
        /// </summary>
        public string DataTypeName { get; private set; }

        /// <summary>
        /// 桁数
        /// </summary>
        public int? Precision { get; private set; }

        /// <summary>
        /// 小数点桁数
        /// </summary>
        public int? Scale { get; private set; }

        // 今のところ無視しておく。もしかしたら使うようになるかもしれない。その場合は、型を見て桁数かサイズを見分けるようにする。
        ///// <summary>
        ///// 文字列長
        ///// </summary>
        //public int? Size { get; private set; }

        /// <summary>
        ///  Nullを許容するか
        /// </summary>
        public bool PermitsNull { get; private set; }

        /// <summary>
        /// デフォルト値
        /// </summary>
        public string DefaultValue { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logicalName"></param>
        /// <param name="physicalName"></param>
        public ColumnModel(string logicalName, string physicalName)
        {
            this.LogicalName = logicalName;
            this.PhysicalName = physicalName;
        }
    }
}
