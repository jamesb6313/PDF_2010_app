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
        //public int[] mapping = new int[] { };
        public List<string> mapping = new List<string>();

        #region Initialization

        /// <summary>
        /// FRM_FieldSelections
        /// </summary>
        public FRM_FieldSelections()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ReadFileColumns
        /// </summary>
        /// <param name="fn"></param>
        private void ReadFileColumns(string fn)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(fn);

                if (lines != null)
                {
                    string[] cols;
                    string fLine = lines[2].ToString();
                    cols = fLine.Split(',');

                    foreach (string c in cols)
                    {
                        LBX_AllFields.Items.Add(c);
                    }
                }
                else
                {
                    MessageBox.Show("No file selected.");
                }
            }
            catch (Exception E1)
            {
                MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message);
                //throw;
            }
        }

        /// <summary>
        /// LoadList
        /// </summary>
        /// <param name="fn"></param>
        internal void LoadList(string fn)
        {
            ReadFileColumns(fn);

            listView1.View = View.Details;
                    
            listView1.Columns.Add("IPAM format");
            listView1.Columns.Add("Map file content");
            listView1.Columns.Add("Map column index");

            string hostName = Form1.curXCELType;
            //listView1.Items.Add(new ListViewItem(new string[] { "Index", "","" }));
            listView1.Items.Add(new ListViewItem(new string[] { "IP", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Status", "Active", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Description", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Hostname", hostName, "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "MAC", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "BLANK", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "BLANK", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Port", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Note", "", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Serial Number", "", "" }));
            listView1.Items.Add(new ListViewItem(new string[] { "Device Location", "", "" }));

            foreach (ColumnHeader col in listView1.Columns)
            {
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                col.Width = 200;
                //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        #endregion

        #region Control Events
        /// <summary>
        /// LBX_AllFields_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBX_AllFields_MouseDown(object sender, MouseEventArgs e)
        {
            //var sndr = (sender as ListBox);

            if (sender is ListBox)
            {

                if (LBX_AllFields.Items.Count == 0)
                    return;

                int index = LBX_AllFields.IndexFromPoint(e.X, e.Y);
                string s = LBX_AllFields.Items[index].ToString();

                s = s + "," + index.ToString();

                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);
                

                if (dde1 == DragDropEffects.All)
                {
                    LBX_AllFields.Items.RemoveAt(LBX_AllFields.IndexFromPoint(e.X, e.Y));
                }

                if (dde1 != DragDropEffects.None)
                {
                    //Start Drag and drop process.
                    this.LBX_AllFields.DoDragDrop(s, DragDropEffects.Copy);
                }
            }
        }

        /// <summary>
        /// listView1_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.StringFormat))     //  StringFormat))
            {
                //Get the drag in text.
                //string str = (string)e.Data.GetData(DataFormats.StringFormat);
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                //
                string[] cols;
                cols = str.Split(',');
                //

                //Get the mouse position.
                Point mousePos = this.listView1.PointToClient(Control.MousePosition);
                //Get the ListViewItem under the mouse.
                ListViewItem item = this.listView1.GetItemAt(mousePos.X, mousePos.Y);

                //Set the text of the ListViewItem.
                if (item == null)
                {
                    e.Effect = DragDropEffects.None;
                    MessageBox.Show("Not a valid row selected");
                    //e.Action = DragAction.Cancel;
                }
                else
                {
                    int index = this.listView1.GetItemAt(mousePos.X, mousePos.Y).Index;

                    switch (index)
                    {
                        case 1:
                            MessageBox.Show("This column is for Status and should be only set to Active");
                            e.Effect = DragDropEffects.None;
                            break;
                        case 5:
                            MessageBox.Show("This column is left as a blank");
                            e.Effect = DragDropEffects.None;
                            break;
                        case 6:
                            MessageBox.Show("This column is left as a blank");
                            e.Effect = DragDropEffects.None;
                            break;
                        case 7:     //Port field
                            MessageBox.Show("The PORT column should be combination of DL#-port & R#-D#, or D#");
                            e.Effect = DragDropEffects.None;
                            if (item.SubItems[1].Text != "")
                            {
                                item.SubItems[1].Text = item.SubItems[1].Text + " & " + cols[0];
                                item.SubItems[2].Text = item.SubItems[2].Text + " & " + cols[1];
                            }
                            else
                            {
                                item.SubItems[1].Text = cols[0];
                                item.SubItems[2].Text = cols[1];
                            }
                            break;
                        case 8:     //NOTE field
                            MessageBox.Show("This NOTE column can be a combination of multiple columns");
                            e.Effect = DragDropEffects.None;
                            if (item.SubItems[1].Text != "")
                            {
                                item.SubItems[1].Text = item.SubItems[1].Text + " & " + cols[0];
                                item.SubItems[2].Text = item.SubItems[2].Text + " & " + cols[1];
                            }
                            else
                            {
                                item.SubItems[1].Text = cols[0];
                                item.SubItems[2].Text = cols[1];
                            }
                            break;
                        default:
                            item.SubItems[1].Text = cols[0];
                            item.SubItems[2].Text = cols[1];
                            break;
                    }

                }
                //item.Text = str;
            }

        }

        /// <summary>
        /// listView1_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                //Data format is legal.
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                //Data format is illegal.
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// listView1_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //Get the mouse position.
            Point mousePos = this.listView1.PointToClient(Control.MousePosition);
            
            //Get the ListViewItem under the mouse.
            ListViewItem item = this.listView1.GetItemAt(mousePos.X, mousePos.Y);
            int index = this.listView1.GetItemAt(mousePos.X, mousePos.Y).Index;

            if (item != null && index != 1)
            {
                item.SubItems[1].Text = "";
                item.SubItems[2].Text = "";
            }
        }

        /// <summary>
        /// BTN_Okay_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Okay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[2].Text == "")
                {
                    mapping.Add("-1");
                }
                else
                {
                    mapping.Add(listView1.Items[i].SubItems[2].Text);
                }
                //int ii = 1;
                //int x;
                //if (Int32.TryParse(listView1.Items[i].SubItems[2].Text, out x))
                //{
                //    mapping[i] = x;
                //}

                //MessageBox.Show(listView1.Items[i].SubItems[2].Text);
                //ii++;
            }
            this.Close();
        }

        /// <summary>
        /// BTN_Cancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
