using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlGeneratorExcelAddIn
{
    /// <summary>
    /// 指定された出力モデルを出力する為のフォームです
    /// </summary>
    public partial class OutputForm : Form
    {
        /// <summary>
        /// 出力対象データの格納用
        /// </summary>
        public IList<OutputDataModel> OutputDataModels { get; set; }

        public OutputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ロードイベントフック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputForm_Load(object sender, EventArgs e)
        {
            if (this.OutputDataModels == null || this.OutputDataModels.Count == 0)
            {
                MessageBox.Show(@"出力データがないよ。だけどめんどくさいからフォームは開くよ");
                return;
            }

            foreach (var outputModel in this.OutputDataModels)
            {
                var textBox = new TextBox();
                textBox.Dock = DockStyle.Fill;
                textBox.Font = new System.Drawing.Font(@"ＭＳ ゴシック", 11, FontStyle.Regular);
                textBox.Multiline = true;
                textBox.Text = outputModel.OutputData;

                var tabPage = new TabPage(outputModel.LogicalName);
                tabPage.Controls.Add(textBox);

                this.tabControl1.TabPages.Add(tabPage);
            }
        }


    }
}
