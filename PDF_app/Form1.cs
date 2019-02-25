#define DEV_ENV
#define TEST_ENV

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text.RegularExpressions;

namespace PDF_app
{
    public partial class Form1 : Form
    {
        private List<myPDFClass> myPDFList = new List<myPDFClass>();
        private List<myIPAMClass> myIPAMList = new List<myIPAMClass>();
        private string curXCELType = "CCTV";
        //private List<myXCELClass> myXCELList = new List<myXCELClass>();

        //private readonly Size DesignSize = new Size(800, 600);
        private readonly Size DesignSize = new Size(1024, 768);

        #region Initialize
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form1_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Set screen & display area independant of screen resolution
            //Makes developement view like screen resolution was 800 * 600 (DesignSize definition above)
           
            //float wGrowth = (float)Screen.PrimaryScreen.Bounds.Width / (float)DesignSize.Width;
            //float hGrowth = (float)Screen.PrimaryScreen.Bounds.Height / (float)DesignSize.Height;

            //if (wGrowth < hGrowth) hGrowth = wGrowth;
            //if (hGrowth > 1)
            //{
            //    this.Font = new Font(this.Font.FontFamily, hGrowth * this.Font.Size);
            //}

            //Set the current directory
#if DEV_ENV
            string dir = @"C:\temp";
#endif
            try
            {
#if DEV_ENV
                Directory.SetCurrentDirectory(dir);    //Get the Current Directory
#endif
                LBLCurDirInfo.Text = Directory.GetCurrentDirectory();
            }
            catch (DirectoryNotFoundException e1)
            {
                MessageBox.Show(String.Format("The specified directory does not exist. Error: {0}", e1.Message));
                //throw;
            }
            GetPDFInput();
            GetCSVInput();

        }
        #endregion

        #region Populate Form Controls
        /// <summary>
        /// getPDFInput
        /// </summary>
        private void GetPDFInput()
        {
            LBX_PDFList.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

            try
            {
                FileInfo[] fis2 = d.GetFiles("*.*");
                foreach (FileInfo fi in fis2)
                {
                    if (fi.Name.ToString().ToLower().Contains(".pdf"))
                        LBX_PDFList.Items.Add(fi.FullName);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error occurred processing. Error: " + err.Message);
                //throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetCSVInput()
        {
            LBX_XCELList.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

            try
            {
                FileInfo[] fis2 = d.GetFiles("*.*");
                foreach (FileInfo fi in fis2)
                {
                    if (fi.Name.ToString().ToLower().Contains(".csv"))
                    {
                        LBX_XCELList.Items.Add(fi.FullName);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error occurred processing. Error: " + err.Message);
                //throw;
            }
        }

        #endregion

        #region Control Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBX_PDFList_SelectedValueChanged(object sender, EventArgs e)
        {
            int Idx = (sender as ListBox).SelectedIndex;

            if (Idx != -1)
            {
                try
                {
                    if ((sender as ListBox).Name.ToLower().Contains("pdf"))
                        TBX_PDFFile.Text = (sender as ListBox).Items[Idx].ToString();
                    else if ((sender as ListBox).Name.ToLower().Contains("xcel"))
                        TBX_XCELFile.Text = (sender as ListBox).Items[Idx].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        /// <summary>
        /// BTNProcessPDF_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNProcessFillDGV_Click(object sender, EventArgs e)
        {
            //var fileType = (sender as Button).Name.ToLower();

            DGV_Info.DataSource = null;
            //myPDFList.Clear();

            DGV_Info.Rows.Clear();
            DGV_Info.Refresh();

            if ((TBX_XCELFile.Text != null) && (TBX_XCELFile.Text.Trim() != ""))
            {
                var form2 = new FRM_XCELType();
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myIPAMList.Clear();
                    curXCELType = form2.XCELType;

                    ReadXCELFile(TBX_XCELFile.Text.Trim(), curXCELType);

                    if (myIPAMList.Count > 0)
                    {
                        DGV_Info.DataSource = myIPAMList;
                        LBL_PDF.Text = curXCELType + " CBS File Type";
                    }
                    //BTN_ProcessXCEL.Visible = false;
                    BTN_UpdatePDF.Visible = true;
                    BTN_SaveIPAM.Visible = true;
                    //BTN_UpdatePDF.Visible = true;
                }
                else { MessageBox.Show("Action Cancelled"); }
            }
            else { MessageBox.Show("No file selected"); }

        }

        /// <summary>
        /// BTNChangeDir_Click()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_ChangeDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(String.Format("Selected directory: {0}", folderBrowserDialog1.SelectedPath));

                try
                {
                    Directory.SetCurrentDirectory(folderBrowserDialog1.SelectedPath);
                    LBLCurDirInfo.Text = Directory.GetCurrentDirectory();
                }
                catch (DirectoryNotFoundException e1)
                {
                    MessageBox.Show(String.Format("The specified directory does not exist. Error : {0}", e1.Message));
                    //throw;
                }

                GetPDFInput();
                GetCSVInput();
            }
        }

        private void BTN_SaveIPAM_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WriteIPAMImportFile(saveFileDialog1.FileName);
            }
        }

        private void BTN_NewPDF_Click(object sender, EventArgs e)
        {
            try
            {
                int Idx = TBX_PDFFile.Text.IndexOf('.');
                if (Idx == 0)
                {
                    MessageBox.Show("Please enter PDF File name");
                    return;
                }
                string newName = TBX_PDFFile.Text.Substring(0, Idx) + "_New.pdf";

                ChangeAnnotations(TBX_PDFFile.Text, newName);
            }
            catch (Exception e1)
                {
                MessageBox.Show(String.Format("Error : {0}", e1.Message));
                //throw;
            }
        }

        #endregion

        #region Read Input File - PDFs, CSV (CCTV,Access Control,Thin Clients)
        /// <summary>
        /// ReadPDFAnnotations()
        /// </summary>
        /// <param name="PDF"></param>
        private void ReadPDFAnnotations(string PDF)
        {
            PdfReader reader = new PdfReader(PDF);
            int cnt = 0;


            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                PdfArray array = reader.GetPageN(i).GetAsArray(PdfName.ANNOTS);
                if (array == null) continue;

                for (int j = 0; j < array.Size; j++)
                {
                    PdfDictionary annot = array.GetAsDict(j);
                    List<PdfName> keys = annot.Keys.ToList();

                    if (annot != null || (annot.Length != 0))
                    {
                        if (annot.Get(PdfName.SUBTYPE).Equals(PdfName.CIRCLE))
                        {

                            PdfString comment = annot.GetAsString(PdfName.CONTENTS);
                            PdfString author = annot.GetAsString(PdfName.T);

                            var subj = keys.Find(x => x.ToString() == "/Subj");
                            var subject = annot.Get(subj);

                            if (author != null)
                            {
                                if (author.ToString().Contains("Legend")) continue;
                                if (author.ToString().Contains("View")) continue;
                                if (author.ToString().Contains("Monitor")) continue;
                            }

                            cnt += 1;
                            myPDFClass temp = new myPDFClass
                            {
                                AnnotID = cnt,
                                Comment = (comment != null) ? Convert.ToString(comment).Trim() : "",
                                Author = (author != null) ? Convert.ToString(author).Trim() : "null!",
                                Subject = (subject != null) ? Convert.ToString(subject).Trim() : "null!"
                            };

                            myPDFList.Add(temp);
                        }
                    }
                }
            }
            reader.Close();
        }

        /// <summary>
        /// ReadIPAMFiles()
        /// </summary>
        /// <param name="searchFile"></param>
        protected void ReadIPAMFiles(string searchFile)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(searchFile);

                //Fill myIPAMList - LIST<myIPAMClass> 
                for (int i = 1; i <= (lines.Count() - 1); i++)
                {
                    string[] cols;
                    string fLine = "";

                    try
                    {
                        fLine = lines[i].ToString();
                        cols = fLine.Split(',');                   

                        myIPAMClass ln = new myIPAMClass
                        {
                            ID = i,
                            IPAddress = cols[0],
                            Status = "Active",
                            Description = cols[2],
                            Hostname = cols[3],
                            Mac = cols[4],
                            TheSwitch = "",
                            Unknown = "",
                            Port = cols[7],
                            Note = cols[8],
                            SerialNumber = cols[9],
                            DeviceLocation = cols[10]
                        };
                        myIPAMList.Add(ln);
                    }
                    catch (Exception E1)
                    {
                        MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message + ", fLine = " + fLine + ", Length = " + fLine.Length);
                        //throw;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while reading the File. Error: " + e.Message);
                //throw;
            }
        }

        /// <summary>
        /// ReadXCELFile()
        /// </summary>
        /// <param name="searchFile"></param>
        /// <param name="type"></param>
        protected void ReadXCELFile(string searchFile, string type)
        {
            try
            {   
                string[] lines = System.IO.File.ReadAllLines(searchFile);

                //Converts CBS CCTV spreadsheet format to IPAM Import Format
                if (type == "CCTV")
                {
                    for (int i = 1; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            if (Int32.TryParse(cols[0], out int x))
                            {
                                // you know that the parsing attempt was successful
                                myIPAMClass ln = new myIPAMClass
                                {
                                    ID = x,   //i is current line number
                                    IPAddress = cols[6],
                                    Status = "Active",
                                    Description = cols[1],
                                    Hostname = "CCTV",
                                    Mac = cols[8],
                                    TheSwitch = "",
                                    Unknown = "",
                                    Port = (cols[3] + " & " + cols[2]).ToUpper(),        //Switch & Data
                                    Note = "",
                                    SerialNumber = cols[9],
                                    DeviceLocation = cols[1]
                                };
                                myIPAMList.Add(ln);
                            }
                            
                        }
                        catch (Exception E1)
                        {
                            MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message + ", fLine = " + fLine + ", line # = " + i);
                            //throw;
                        }
                    }
                }

                //Converts CBS Access Control spreadsheet format to IPAM Import Format
                if (type == "Access Control") {
                
                    for (int i = 1; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            if (Int32.TryParse(cols[0], out int x))
                            {
                                // you know that the parsing attempt was successful
                                myIPAMClass ln = new myIPAMClass
                                {
                                    ID = x,
                                    IPAddress = cols[6],
                                    Status = "Active",
                                    Description = cols[1],
                                    Hostname = "Access Control",
                                    Mac = cols[7],
                                    TheSwitch = "",
                                    Unknown = "",
                                    Port = (cols[2] + " & " + cols[3]).ToUpper(),        //Switch & Data
                                    Note = "",
                                    SerialNumber = cols[8],
                                    DeviceLocation = cols[1]
                                };
                                myIPAMList.Add(ln);
                            }
                        }
                        catch (Exception E1)
                        {
                            MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message + ", fLine = " + fLine + ", line # = " + i);
                            //throw;
                        }
                    }
                }

                //Converts CBS Workstations spreadsheet format to IPAM Import Format
                if (type == "Workstations")
                {

                    for (int i = 1; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');                

                            myIPAMClass ln = new myIPAMClass
                            {
                                ID = i,
                                IPAddress = cols[0],
                                Status = "Active",
                                Description = cols[2],
                                Hostname = cols[3],
                                Mac = cols[4],
                                TheSwitch = "",
                                Unknown = "",
                                Port = cols[7],        //Switch & Data
                                Note = cols[8],
                                SerialNumber = cols[9],
                                DeviceLocation = cols[10]
                            };
                            myIPAMList.Add(ln);
                        }
                        catch (Exception E1)
                        {
                            MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message + ", fLine = " + fLine + ", Length = " + fLine.Length);
                            //throw;
                        }
                    }
                }

                // No conversion
                if (type == "IPAM Import")
                {

                    for (int i = 1; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');                   

                            myIPAMClass ln = new myIPAMClass
                            {
                                ID = i,
                                IPAddress = cols[0],
                                Status = cols[1],
                                Description = cols[2],
                                Hostname = cols[3],
                                Mac = cols[4],
                                TheSwitch = cols[5],
                                Unknown = cols[6],
                                Port = cols[7],        //Switch & Data
                                Note = cols[8],
                                SerialNumber = cols[9],
                                DeviceLocation = cols[10]
                            };
                            myIPAMList.Add(ln);
                        }
                        catch (Exception E1)
                        {
                            MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message + ", fLine = " + fLine + ", Length = " + fLine.Length);
                            //throw;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while reading the File. Error: " + e.Message);
                //throw;
            }

        }
        #endregion

        #region Write output - PDFs and IPAM CSVs
        /// <summary>
        /// ChangeAnnotations
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        void ChangeAnnotations(string inputPath, string outputPath)
        {
            if (DGV_Info.DataSource == null)
            {
                MessageBox.Show("Input source is Grid. Please fill Grid");
                return;
                
            }
            PdfReader reader = new PdfReader(inputPath);
            PdfStamper pdfStamper = new PdfStamper(reader, new FileStream(outputPath, FileMode.Create));
            ////

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                PdfArray array = reader.GetPageN(i).GetAsArray(PdfName.ANNOTS);
                if (array == null) continue;

                for (int j = 0; j < array.Size; j++)
                {
                    PdfDictionary annot = array.GetAsDict(j);
                    List<PdfName> keys = annot.Keys.ToList();

                    if (annot != null || (annot.Length != 0))
                    {
                        if (annot.Get(PdfName.SUBTYPE).Equals(PdfName.CIRCLE))
                        {

                            PdfString comment = annot.GetAsString(PdfName.CONTENTS);
                            PdfString author = annot.GetAsString(PdfName.T);

                            var subj = keys.Find(x => x.ToString() == "/Subj");
                            var subject = annot.Get(subj);

                            if ((author != null) && (author.ToString().Contains("Legend"))) continue;

                            if (curXCELType == "Access Control")
                            {
                                if ((comment != null) && (comment.ToString().Contains("AC")))
                                {
                                    var cmtSegs = comment.ToString().Split(' ');
                                    var acNum = 0;
                                    foreach (string c in cmtSegs)
                                    {
                                        if (c.Contains("AC"))
                                        {
                                            string acNo = c.Substring(c.IndexOf("AC") + 2);


                                            if (Int32.TryParse(acNo, out int x))
                                            {
                                                // you know that the parsing attempt was successful
                                                acNum = x;
                                            }
                                            break;
                                        }
                                    }
                                    if (acNum == 0)
                                    {
                                        MessageBox.Show("Could not get AC number from comment. Need Format AC# where # is between 1 and 999");
                                    }

                                    var IPAMQry =
                                        from DataGridViewRow rowView in DGV_Info.Rows
                                        select rowView;
                                    /*
                                    var testQry =
                                        from DataGridViewRow rowView in dgvRr
                                        where (
                                        (string.Compare(rowView.Cells["LINE"].Value.ToString(), vrMSCLineNo) == 0) &&
                                        (string.Compare(rowView.Cells["SPECIFIC_NUMBERS"].Value.ToString(), "") != 0)
                                        )
                                        select rowView;
                                    */
                                    foreach (var row in IPAMQry)
                                    {
                                        var acRow = row.Cells[0].Value.ToString();
                                        if (acNum.ToString() == acRow)
                                        {
                                            var updateComment = "AC" + row.Cells[0].Value.ToString() + "; " +
                                                row.Cells[1].Value.ToString() + "; " +
                                                row.Cells[8].Value.ToString();

                                            annot.Put(PdfName.CONTENTS, new PdfString(updateComment.ToString()));
                                        }

                                    }

                                }
                            }
                            
                            if (curXCELType == "CCTV")
                            {
                                if ((comment != null) && (comment.ToString().Contains("C-")))
                                {
                                    var cmtSegs = comment.ToString().Split(' ');
                                    var acNum = 0;
                                    foreach (string c in cmtSegs)
                                    {
                                        if (c.Contains("C-"))
                                        {
                                            string acNo = c.Substring(c.IndexOf("C-") + 2);


                                            if (Int32.TryParse(acNo, out int x))
                                            {
                                                // you know that the parsing attempt was successful
                                                acNum = x;
                                            }
                                            break;
                                        }
                                    }
                                    if (acNum == 0)
                                    {
                                        MessageBox.Show("Could not get Camera number (C-) from comment. Need Format AC# where # is between 1 and 999");
                                    }

                                    var IPAMQry =
                                        from DataGridViewRow rowView in DGV_Info.Rows
                                        select rowView;
                                    /*
                                    var testQry =
                                        from DataGridViewRow rowView in dgvRr
                                        where (
                                        (string.Compare(rowView.Cells["LINE"].Value.ToString(), vrMSCLineNo) == 0) &&
                                        (string.Compare(rowView.Cells["SPECIFIC_NUMBERS"].Value.ToString(), "") != 0)
                                        )
                                        select rowView;
                                    */
                                    foreach (var row in IPAMQry)
                                    {
                                        var acRow = row.Cells[0].Value.ToString();
                                        if (acNum.ToString() == acRow)
                                        {
                                            var updateComment = "C-" + row.Cells[0].Value.ToString() + "; " +
                                                row.Cells[1].Value.ToString() + "; " +
                                                row.Cells[8].Value.ToString();

                                            annot.Put(PdfName.CONTENTS, new PdfString(updateComment.ToString()));
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
            pdfStamper.Close();
        }

        /// <summary>
        /// WriteXCELFile()
        /// </summary>
        /// <param name="searchFile"></param>
        /// <param name="type"></param>
        protected void WriteIPAMImportFile(string searchFile)
        {
            try
            {
                StreamWriter IPAMImportFile = new StreamWriter(searchFile);

                var IPAMQry =
                    from DataGridViewRow rowView in DGV_Info.Rows
                    select rowView;

                foreach (var row in IPAMQry)
                {
                    string outLine = null;

                    for (var i = 1; i <= (row.Cells.Count - 1); i++)
                    {
                        if (i == 1)
                            outLine = row.Cells[i].Value.ToString();
                        else
                            outLine = outLine + "," + row.Cells[i].Value.ToString();
                    }
                    IPAMImportFile.WriteLine(outLine);
                }
                IPAMImportFile.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while reading the File. Error: " + e.Message);
                //throw;
            }

        }
        #endregion

        private void BTN_UpdatePDF_Click(object sender, EventArgs e)
        {
            if (myIPAMList.Count <= 0) {
                MessageBox.Show("Nothing to update PDF information.");
            }

            string hn = "";

            if (curXCELType == "Access Control") hn = "Access Control";
            if (curXCELType == "CCTV") hn = "Camera";
            else
            {
                MessageBox.Show("Can only update CCTV oe Access Control PDF information.");
            }

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //WriteIPAMImportFile(saveFileDialog1.FileName);
                string fn = openFileDialog1.FileName.Trim();

                if ((fn != null) && (fn != ""))
                {
                    myPDFList.Clear();
                    ReadPDFAnnotations(fn);

                    if (myIPAMList.Count > 0)
                        UpdatePDFInfo();

                    if (myPDFList.Count > 0)
                    {
                        var chgdList = myPDFList.FindAll(x => x.Subject.Contains(hn));

                        DGV_Info.DataSource = chgdList;
                        LBL_PDF.Text = hn + " File Information";
                        //DGV_Info.Columns["AnnotID"].ReadOnly = true;
                        //DGV_Info.Columns["Author"].ReadOnly = true;
                        //DGV_Info.Columns["Subject"].ReadOnly = true;
                    }
                }
                else
                { MessageBox.Show("No file selected"); }
            }
        }

        private void UpdatePDFInfo()
        {

            if (curXCELType == "CCTV")
            {
                //CCTV 
                var IPAMQry =
                    from DataGridViewRow rowView in DGV_Info.Rows
                    select rowView;

                foreach (var row in IPAMQry)
                {
                    var desc = row.Cells[3].Value.ToString();   //description field
                    if ((desc != null) && (desc.ToString().Contains("C-")))
                    {
                        var cmtSegs = desc.ToString().Split(' ');
                        var acNum = 0;
                        foreach (string c in cmtSegs)
                        {
                            if (c.Contains("C-"))
                            {
                                var strEnd = c.Substring(c.IndexOf("C-") + 1);

                                var stripped = Regex.Replace(strEnd, "[^0-9]", "");
                                if (Int32.TryParse(stripped, out int x))
                                {
                                    // you know that the parsing attempt was successful
                                    acNum = x;
                                }
                                break;
                            }
                        }

                        if (acNum == 0)
                        {
                            MessageBox.Show("Could not get C- number from comment. Need Format C-# where # is between 1 and 999");
                        }
                        else //Find in myPDFList
                        {
                            string acIdx = "C-" + acNum.ToString();
                            int commentNum = 0;
                            foreach (var item in myPDFList)
                            {
                                //var cmtSegs = item.Comment.ToString().Split(' ');
                                //var acNum = 0;
                                foreach (string c in item.Comment.ToString().Split(' '))
                                {
                                    if (c.Contains("C-"))
                                    {

                                        var stripped = Regex.Replace(c, "[^0-9]", "");
                                        if (Int32.TryParse(stripped, out int x))
                                        {
                                            // you know that the parsing attempt was successful
                                            commentNum = x;
                                        }
                                        break;
                                    }
                                }
                                if (commentNum == acNum)
                                {
                                    item.NewComment = acIdx + "; " +
                                            row.Cells[1].Value.ToString() + "; " +
                                            row.Cells[8].Value.ToString();
                                    break;

                                }

                            }
                            //var item = myPDFList.Find(x => x.Comment.ToString().Equals(acIdx));     //NEED TO DISTINGUSH BETWEEN C-1 & C-10, C-11.... Also have "(C-12)" therefore Equals no good
                            //if (item != null)

                        }
                    }

                }

            }
            else if (curXCELType == "Access Control")
            {
                //Access Control
                var IPAMQry =
                    from DataGridViewRow rowView in DGV_Info.Rows
                    select rowView;

                foreach (var row in IPAMQry)
                {
                    var desc = row.Cells[3].Value.ToString();   //description field
                    if ((desc != null) && (desc.ToString().Contains("AC")))
                    {
                        var cmtSegs = desc.ToString().Split(' ');
                        var acNum = 0;
                        foreach (string c in cmtSegs)
                        {
                            if (c.Contains("AC"))
                            {

                                var stripped = Regex.Replace(c, "[^0-9]", "");
                                if (Int32.TryParse(stripped, out int x))
                                {
                                    // you know that the parsing attempt was successful
                                    acNum = x;
                                }
                                break;
                            }
                        }

                        if (acNum == 0)
                        {
                            MessageBox.Show("Could not get AC number from comment. Need Format AC# where # is between 1 and 999");
                        }
                        else //Find in myPDFList
                        {
                            string acIdx = "AC" + acNum.ToString();

                            int commentNum = 0;
                            foreach (var item in myPDFList)
                            {
                                //var cmtSegs = item.Comment.ToString().Split(' ');
                                //var acNum = 0;
                                foreach (string c in item.Comment.ToString().Split(' '))
                                {
                                    if (c.Contains("AC"))
                                    {

                                        var stripped = Regex.Replace(c, "[^0-9]", "");
                                        if (Int32.TryParse(stripped, out int x))
                                        {
                                            // you know that the parsing attempt was successful
                                            commentNum = x;
                                        }
                                        break;
                                    }
                                }
                                if (commentNum == acNum)
                                {
                                    item.NewComment = acIdx + "; " +
                                            row.Cells[1].Value.ToString() + "; " +
                                            row.Cells[8].Value.ToString();
                                    break;

                                }
                            }
                            //    var item = myPDFList.Find(x => x.Comment.ToString().Contains(acIdx));
                            //if (item != null)
                            //{
                            //    item.NewComment = acIdx + "; " +
                            //          row.Cells[1].Value.ToString() + "; " +
                            //          row.Cells[8].Value.ToString();
                            //}
                        }
                    }

                 }

            }

        }

        private void ReadFileColumns(string fn)
        {

            string[] lines = System.IO.File.ReadAllLines(fn);
            for (int i = 1; i <= (lines.Count() - 1); i++)
            {
                string[] cols;
                string fLine = "";

                try
                {
                    fLine = lines[i].ToString();
                    cols = fLine.Split(',');

                    if (Int32.TryParse(cols[0], out int x))
                    {
                        // you know that the parsing attempt was successful
                        myIPAMClass ln = new myIPAMClass
                        {
                            ID = x,   //i is current line number
                            IPAddress = cols[6],
                            Status = "Active",
                            Description = cols[1],
                            Hostname = "CCTV",
                            Mac = cols[8],
                            TheSwitch = "",
                            Unknown = "",
                            Port = (cols[3] + " & " + cols[2]).ToUpper(),        //Switch & Data
                            Note = "",
                            SerialNumber = cols[9],
                            DeviceLocation = cols[1]
                        };
                        myIPAMList.Add(ln);
                    }

                }
                catch (Exception E1)
                {
                    MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message + ", fLine = " + fLine + ", line # = " + i);
                    //throw;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            /******
                            FRM_DisplayImage PhotoListForm = new FRM_DisplayImage();
                PhotoListForm.LoadList(Photos, CurrentPhotoLists);
                PhotoListForm.Show();

            ReadFileColumns(TBX_XCELFile.Text.Trim());

        *****/
            var form2 = new FRM_FieldSelections();
            form2.LoadList(TBX_XCELFile.Text.Trim());
            if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //myIPAMList.Clear();
                //curXCELType = form2.XCELType;
            }
            else { MessageBox.Show("Action Cancelled"); }
        }
    }
}
