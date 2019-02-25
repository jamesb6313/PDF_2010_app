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
    public partial class FRM_FieldSelections : Form
    {
        public FRM_FieldSelections()
        {
            InitializeComponent();
        }

        private void ReadFileColumns(string fn)
        {

            string[] lines = System.IO.File.ReadAllLines(fn);

                string[] cols;
                string fLine = lines[2].ToString();

                try
                {

                    cols = fLine.Split(',');

                    foreach (string c in cols)
                    {
                        LBX_AllFields.Items.Add(c);
                    }

                }
                catch (Exception E1)
                {
                    MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message);
                    //throw;
                }



        }

        internal void LoadList(string fn)
        {
            ReadFileColumns(fn);
        }

        
        // Move selected items from one ListBox to another.
        private void MoveSelectedItems(ListBox lstFrom, ListBox lstTo)
        {
            while (lstFrom.SelectedItems.Count > 0)
            {
                string item = (string)lstFrom.SelectedItems[0];
                lstTo.Items.Add(item);
                lstFrom.Items.Remove(item);
            }
            //SetButtonsEditable();
        }

        // Move all items from one ListBox to another.
        private void MoveAllItems(ListBox lstFrom, ListBox lstTo)
        {
            lstTo.Items.AddRange(lstFrom.Items);
            lstFrom.Items.Clear();
            //SetButtonsEditable();
        }

        // Enable and disable buttons.
        private void SetButtonsEditable()
        {
            BTN_SelectedRight.Enabled = (LBX_Selected.SelectedItems.Count > 0);
            BTN_AllRight.Enabled = (LBX_Selected.Items.Count > 0);
            BTN_SelectedLeft.Enabled = (LBX_AllFields.SelectedItems.Count > 0);
            BTN_AllLeft.Enabled = (LBX_AllFields.Items.Count > 0);
        }

        private void BTN_SelectedRight_Click(object sender, EventArgs e)
        {
            // Move selected items to lstSelected.
            MoveSelectedItems(LBX_AllFields, LBX_Selected);
        }

        private void BTN_SelectedLeft_Click(object sender, EventArgs e)
        {
            // Move selected items to lstUnselected.
            MoveSelectedItems(LBX_Selected, LBX_AllFields);
        }

        private void BTN_AllRight_Click(object sender, EventArgs e)
        {
            // Move all items to lstSelected.
            MoveAllItems(LBX_AllFields, LBX_Selected);
        }

        private void BTN_AllLeft_Click(object sender, EventArgs e)
        {
            // Move all items to lstUnselected.
            MoveAllItems(LBX_Selected, LBX_AllFields);
        }

        /*

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

    */
    }
}
