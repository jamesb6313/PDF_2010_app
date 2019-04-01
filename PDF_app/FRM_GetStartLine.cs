using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDF_app
{
    public partial class FRM_GetStartLine : Form
    {
        public static int fileStartLine = 0;
        string[] lines;
        string curLine;

        public FRM_GetStartLine()
        {
            InitializeComponent();

            try
            {
                lines = System.IO.File.ReadAllLines(Form1.curFileName);

                if (lines.Count() > 0)
                {
                    fileStartLine = 0;
                    curLine = lines[fileStartLine].ToString();
                    LBL_FileLine.Text = curLine;
                }
                else
                {
                    MessageBox.Show("File is empty. Please try again.");
                    //this.DialogResult = DialogResult.Cancel;
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the File. Error: " + ex.Message);
            }
        }

        private void BTN_NextLine_Click(object sender, EventArgs e)
        {
            if (fileStartLine >= lines.Count() - 1)
            {
                MessageBox.Show("Reached Last Line of File");
            }
            else
            {
                fileStartLine = fileStartLine + 1;
            
                curLine = lines[fileStartLine].ToString();
                LBL_FileLine.Text = curLine;
            }
        }

        private void BTN_Okay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTN_GetPrevious_Click(object sender, EventArgs e)
        {
            if (fileStartLine <= 0)
            {
                MessageBox.Show("Reached First Line of File");
            }
            else
            {
                fileStartLine = fileStartLine - 1;

                curLine = lines[fileStartLine].ToString();
                LBL_FileLine.Text = curLine;
            }
        }
    }
}
