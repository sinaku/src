using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.IO;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// Excelに追加するリボンコントロールです。
    /// </summary>
    public partial class SqlGeneratorRibbon
    {
        /// <summary>
        /// 画面出力用のフォーム
        /// </summary>
        private OutputForm _outputForm;


        private void SqlGeneratorRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        /// <summary>
        /// Select文をテーブル定義書に従い生成します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSqlGeneration_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var tableModels = this.GetTableModels();
                var sqlGenerator = new SqlGenerator(this._asSets.Checked);
                var sqlList = sqlGenerator.GetSelectSqlList(tableModels);

                this.ShowOutputDataModels(sqlList);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// テーブルクリエイト文をテーブル定義書に従い生成します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableCreateSqlGeneration_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var tableModels = this.GetTableModels();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Entityクラスをテーブル定義書に従い生成します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntityGeneration_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var tableModels = this.GetTableModels();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// テーブルモデルリストの取得を行います。
        /// </summary>
        /// <returns>
        /// テーブルモデルのリストです。
        /// </returns>
        private List<TableModel> GetTableModels()
        {
            var excelAnalysis =
                new ExcelAnalysis(
                    this._entityLogicalNameAddress.Text,
                    this._entityPhysicalNameAddress.Text,
                    this._readStartRowIndex.Text,
                    this._itemLogicalNameColumn.Text,
                    this._itemPhysicalNameColumn.Text);
            return excelAnalysis.GetTableModels();
        }

        /// <summary>
        /// データの出力を指定された出力位置に対して行います。
        /// </summary>
        /// <param name="outputDataModels">出力対象データ</param>
        private void ShowOutputDataModels(List<OutputDataModel> outputDataModels)
        {
            if (outputDataModels == null)
                throw new ArgumentNullException(@"出力指定されたデータにnullが指定されています。");
            if (outputDataModels.Count == 0)
                throw new ArgumentOutOfRangeException(@"指定されたデータ件数が0件です。出力対象データが1件以上必要です。");

            if (this._outputForm != null && !this._outputForm.IsDisposed)
                this._outputForm.Dispose();

            this._outputForm = new OutputForm();
            this._outputForm.OutputDataModels = outputDataModels;

            this._outputForm.Show();

        }
    }
}
