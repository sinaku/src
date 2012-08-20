namespace SqlGeneratorExcelAddIn
{
    partial class SqlGeneratorRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// デザイナー変数が必要です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public SqlGeneratorRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if(this._outputForm != null && !this._outputForm.IsDisposed)
                this._outputForm.Dispose();
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this._selectSqlGeneration = this.Factory.CreateRibbonButton();
            this._tableCreateSqlGeneration = this.Factory.CreateRibbonButton();
            this._entityGeneration = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this._asSets = this.Factory.CreateRibbonCheckBox();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.comboBox1 = this.Factory.CreateRibbonComboBox();
            this.group4 = this.Factory.CreateRibbonGroup();
            this._entityLogicalNameAddress = this.Factory.CreateRibbonEditBox();
            this._entityPhysicalNameAddress = this.Factory.CreateRibbonEditBox();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this._readStartRowIndex = this.Factory.CreateRibbonEditBox();
            this._itemLogicalNameColumn = this.Factory.CreateRibbonEditBox();
            this._itemPhysicalNameColumn = this.Factory.CreateRibbonEditBox();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this._dataTypeNameColumn = this.Factory.CreateRibbonEditBox();
            this._precisionColumn = this.Factory.CreateRibbonEditBox();
            this._scaleColumn = this.Factory.CreateRibbonEditBox();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this._isKeyColumn = this.Factory.CreateRibbonEditBox();
            this._permitsNullColumn = this.Factory.CreateRibbonEditBox();
            this._defaultValueColumn = this.Factory.CreateRibbonEditBox();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this._selectSqlGeneration);
            this.group1.Items.Add(this._tableCreateSqlGeneration);
            this.group1.Items.Add(this._entityGeneration);
            this.group1.Label = "出力";
            this.group1.Name = "group1";
            // 
            // _selectSqlGeneration
            // 
            this._selectSqlGeneration.Label = "Select文生成";
            this._selectSqlGeneration.Name = "_selectSqlGeneration";
            this._selectSqlGeneration.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SelectSqlGeneration_Click);
            // 
            // _tableCreateSqlGeneration
            // 
            this._tableCreateSqlGeneration.Label = "Create文生成";
            this._tableCreateSqlGeneration.Name = "_tableCreateSqlGeneration";
            this._tableCreateSqlGeneration.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TableCreateSqlGeneration_Click);
            // 
            // _entityGeneration
            // 
            this._entityGeneration.Label = "Entityクラス生成";
            this._entityGeneration.Name = "_entityGeneration";
            this._entityGeneration.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.EntityGeneration_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this._asSets);
            this.group2.Label = "Select文生成時のオプション";
            this.group2.Name = "group2";
            // 
            // _asSets
            // 
            this._asSets.Label = "カラムの別名を付ける際にASを設定するか";
            this._asSets.Name = "_asSets";
            // 
            // group3
            // 
            this.group3.Items.Add(this.comboBox1);
            this.group3.Label = "出力オプション";
            this.group3.Name = "group3";
            // 
            // comboBox1
            // 
            this.comboBox1.Label = "出力位置";
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Text = null;
            // 
            // group4
            // 
            this.group4.Items.Add(this._entityLogicalNameAddress);
            this.group4.Items.Add(this._entityPhysicalNameAddress);
            this.group4.Items.Add(this.separator1);
            this.group4.Items.Add(this._readStartRowIndex);
            this.group4.Items.Add(this._itemLogicalNameColumn);
            this.group4.Items.Add(this._itemPhysicalNameColumn);
            this.group4.Items.Add(this.separator2);
            this.group4.Items.Add(this._dataTypeNameColumn);
            this.group4.Items.Add(this._precisionColumn);
            this.group4.Items.Add(this._scaleColumn);
            this.group4.Items.Add(this.separator3);
            this.group4.Items.Add(this._isKeyColumn);
            this.group4.Items.Add(this._permitsNullColumn);
            this.group4.Items.Add(this._defaultValueColumn);
            this.group4.Label = "定義書読込方法指定";
            this.group4.Name = "group4";
            // 
            // _entityLogicalNameAddress
            // 
            this._entityLogicalNameAddress.Label = "Entity物理名定義位置";
            this._entityLogicalNameAddress.Name = "_entityLogicalNameAddress";
            this._entityLogicalNameAddress.Text = null;
            // 
            // _entityPhysicalNameAddress
            // 
            this._entityPhysicalNameAddress.Label = "Entity論理名定義位置";
            this._entityPhysicalNameAddress.Name = "_entityPhysicalNameAddress";
            this._entityPhysicalNameAddress.Text = null;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // _readStartRowIndex
            // 
            this._readStartRowIndex.Label = "項目読込開始行";
            this._readStartRowIndex.Name = "_readStartRowIndex";
            this._readStartRowIndex.Text = null;
            // 
            // _itemLogicalNameColumn
            // 
            this._itemLogicalNameColumn.Label = "項目物理名定義列";
            this._itemLogicalNameColumn.Name = "_itemLogicalNameColumn";
            this._itemLogicalNameColumn.Text = null;
            // 
            // _itemPhysicalNameColumn
            // 
            this._itemPhysicalNameColumn.Label = "項目論理名定義列";
            this._itemPhysicalNameColumn.Name = "_itemPhysicalNameColumn";
            this._itemPhysicalNameColumn.Text = null;
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // _dataTypeNameColumn
            // 
            this._dataTypeNameColumn.Label = "型定義列";
            this._dataTypeNameColumn.Name = "_dataTypeNameColumn";
            this._dataTypeNameColumn.Text = null;
            // 
            // _precisionColumn
            // 
            this._precisionColumn.Label = "桁数定義列";
            this._precisionColumn.Name = "_precisionColumn";
            this._precisionColumn.Text = null;
            // 
            // _scaleColumn
            // 
            this._scaleColumn.Label = "小数点以下桁数定義列";
            this._scaleColumn.Name = "_scaleColumn";
            this._scaleColumn.Text = null;
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // _isKeyColumn
            // 
            this._isKeyColumn.Label = "Key定義列";
            this._isKeyColumn.Name = "_isKeyColumn";
            this._isKeyColumn.Text = null;
            // 
            // _permitsNullColumn
            // 
            this._permitsNullColumn.Label = "Null許容定義列";
            this._permitsNullColumn.Name = "_permitsNullColumn";
            this._permitsNullColumn.Text = null;
            // 
            // _defaultValueColumn
            // 
            this._defaultValueColumn.Label = "デフォルト値定義列";
            this._defaultValueColumn.Name = "_defaultValueColumn";
            this._defaultValueColumn.Text = null;
            // 
            // SqlGeneratorRibbon
            // 
            this.Name = "SqlGeneratorRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.SqlGeneratorRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton _selectSqlGeneration;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton _tableCreateSqlGeneration;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton _entityGeneration;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox _asSets;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _entityLogicalNameAddress;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _entityPhysicalNameAddress;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _itemLogicalNameColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _itemPhysicalNameColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _isKeyColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _permitsNullColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _defaultValueColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _dataTypeNameColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _precisionColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _scaleColumn;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox _readStartRowIndex;
    }

    partial class ThisRibbonCollection
    {
        internal SqlGeneratorRibbon SqlGeneratorRibbon
        {
            get { return this.GetRibbon<SqlGeneratorRibbon>(); }
        }
    }
}
