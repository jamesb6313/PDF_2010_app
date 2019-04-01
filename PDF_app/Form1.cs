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
        public static string curXCELType = "CCTV";
        public static string curFileName = "";

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
            //GetPDFInput();
            CBX_FileType.Text = "Excel - CSV";
            GetCSVInput();

        }
        #endregion

        #region Populate Form Controls
        /// <summary>
        /// GetPDFInput
        /// </summary>
        private void GetPDFInput()
        {
            LBX_FileList.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

            try
            {
                FileInfo[] fis2 = d.GetFiles("*.*");
                foreach (FileInfo fi in fis2)
                {
                    if (fi.Name.ToString().ToLower().Contains(".pdf"))
                        LBX_FileList.Items.Add(fi.FullName);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error occurred processing. Error: " + err.Message);
                //throw;
            }
        }

        /// <summary>
        /// GetCSVInput
        /// </summary>
        private void GetCSVInput()
        {
            LBX_FileList.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

            try
            {
                FileInfo[] fis2 = d.GetFiles("*.*");
                foreach (FileInfo fi in fis2)
                {
                    if (fi.Name.ToString().ToLower().Contains(".csv"))
                    {
                        LBX_FileList.Items.Add(fi.FullName);
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
        /// LBX_FileList_SelectedValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBX_FileList_SelectedValueChanged(object sender, EventArgs e)
        {
            int Idx = (sender as ListBox).SelectedIndex;

            if (Idx != -1)
            {
                try
                {
                    TBX_File.Text = (sender as ListBox).Items[Idx].ToString();
                    curFileName = TBX_File.Text;
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

            if ((TBX_File.Text != null) && (TBX_File.Text.Trim() != ""))
            {
                var form2 = new FRM_XCELType();
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myIPAMList.Clear();
                    curXCELType = form2.XCELType;

                    ReadCSVFile(TBX_File.Text.Trim(), curXCELType);

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
        /// BTNChangeDir_Click
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

                if (CBX_FileType.Text.Contains("CSV"))
                    GetCSVInput();
                else
                    GetPDFInput();

            }
        }

        /// <summary>
        /// BTN_SaveIPAM_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_SaveIPAM_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WriteIPAMImportFile(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// BTN_NewPDF_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_NewPDF_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string fn = openFileDialog1.FileName.Trim();

                    if ((fn != null) && (fn != ""))
                    {

                        int Idx = fn.IndexOf('.');
                        if (Idx == 0)
                        {
                            MessageBox.Show("Please enter PDF File name");
                            return;
                        }
                        string newName = fn.Substring(0, Idx) + "_New.pdf";

                        ChangeAnnotations(fn, newName);
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(String.Format("Error : {0}", e1.Message));
                //throw;
            }

            //try
            //{
            //    int Idx = TBX_File.Text.IndexOf('.');
            //    if (Idx == 0)
            //    {
            //        MessageBox.Show("Please enter PDF File name");
            //        return;
            //    }
            //    string newName = TBX_File.Text.Substring(0, Idx) + "_New.pdf";

            //    ChangeAnnotations(TBX_File.Text, newName);
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(String.Format("Error : {0}", e1.Message));
            //    //throw;
            //}
        }

        /// <summary>
        /// CBX_FIleType_SelectedValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBX_FileType_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Text.Contains("CSV"))
                GetCSVInput();
            else
                GetPDFInput();
        }

        /// <summary>
        /// BTN_Mapping_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Mapping_Click(object sender, EventArgs e)
        {

            GetHostname();

            if (curXCELType != "")
            {
                var form3 = new FRM_FieldSelections();
                form3.LoadList(TBX_File.Text.Trim());

                if (form3.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myIPAMList.Clear();

                    string[] lines = System.IO.File.ReadAllLines(TBX_File.Text.Trim());
                    if (lines.Count() <= 0)
                    {
                        MessageBox.Show("Cannot process empty file. Please try again.");
                        return;
                    }

                    int start = DetermineStartLine();

                    if (start == -1)
                    {
                        MessageBox.Show("Cannot process file without knowing the first line of data. Please try again.");
                        return;
                    }

                    for (int i = start; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            //int x;
                            //if (Int32.TryParse(cols[0], out x))
                            //{
                            // you know that the parsing attempt was successful

                            string s;
                            int mapIdx;

                            myIPAMClass ln = new myIPAMClass { };
                            //ln.ID = i - (start - 1);
                            //IP
                            s = form3.mapping[0];
                            if (s != "-1")
                            {
                                mapIdx = Int32.Parse(s);
                                ln.IPAddress = cols[mapIdx];
                            }
                            else ln.IPAddress = "";

                            //Status
                            ln.Status = "Active";

                            //Description
                            s = form3.mapping[2];
                            if (s != "-1")
                            {
                                mapIdx = Int32.Parse(s);
                                ln.Description = cols[mapIdx];
                            }
                            else ln.Description = "";

                            //Hostname
                            ln.Hostname = curXCELType;

                            //MAC
                            s = form3.mapping[4];
                            if (s != "-1")
                            {
                                mapIdx = Int32.Parse(s);
                                ln.Mac = cols[mapIdx];
                            }
                            else ln.Mac = "";

                            ln.TheSwitch = "";
                            ln.Unknown = "";

                            //Port
                            s = form3.mapping[7];
                            if (s != "-1")
                            {
                                if (s.Contains("&"))
                                {
                                    string[] prts;
                                    prts = s.Split('&');

                                    int mp = Int32.Parse(prts[0]);
                                    mapIdx = Int32.Parse(prts[1]);
                                    ln.Port = (cols[mp] + " & " + cols[mapIdx]).ToUpper();
                                }
                                else
                                {
                                    mapIdx = Int32.Parse(s);
                                    ln.Port = cols[mapIdx].ToUpper();
                                }
                            }
                            else ln.Port = "";
                            //ln.Port.ToUpper();

                            //Note
                            s = form3.mapping[8];
                            if (s != "-1")
                            {
                                if (s.Contains("&"))
                                {
                                    string[] prts;
                                    prts = s.Split('&');
                                    string note = "";

                                    foreach (var p in prts)
                                    {
                                        mapIdx = Int32.Parse(p);
                                        if (cols[mapIdx] != "")
                                        {
                                            if (note == "") note = cols[mapIdx];
                                            else note = note + " & " + cols[mapIdx];
                                        }
                                    }
                                    ln.Note = note;
                                }
                                else
                                {
                                    mapIdx = Int32.Parse(s);
                                    ln.Note = cols[mapIdx];
                                }
                            }
                            else ln.Note = "";

                            //SerialNumber
                            s = form3.mapping[9];
                            if (s != "-1")
                            {
                                mapIdx = Int32.Parse(s);
                                ln.SerialNumber = cols[mapIdx];
                            }
                            else ln.SerialNumber = "";


                            //DeviceLocation
                            s = form3.mapping[10];
                            if (s != "-1")
                            {
                                mapIdx = Int32.Parse(s);
                                ln.DeviceLocation = cols[mapIdx];
                            }
                            else ln.DeviceLocation = "";

                            myIPAMList.Add(ln);
                            // }
                        }
                        catch (Exception E1)
                        {
                            MessageBox.Show("An error occurred while processing the File. Error: " + E1.Message);
                            //throw;
                        }
                    }


                    if (myIPAMList.Count > 0)
                    {
                        DGV_Info.DataSource = null;
                        DGV_Info.Rows.Clear();
                        DGV_Info.Refresh();

                        DGV_Info.DataSource = myIPAMList;
                        LBL_PDF.Text = "User mapping of Input File";
                    }
                    //BTN_ProcessXCEL.Visible = false;
                    BTN_UpdatePDF.Visible = true;
                    BTN_SaveIPAM.Visible = true;
                }
                else { MessageBox.Show("Action Cancelled"); }
            }

        }


        /// <summary>
        /// BTN_UpdatePDF_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_UpdatePDF_Click(object sender, EventArgs e)
        {
            if (myIPAMList.Count <= 0)
            {
                MessageBox.Show("Nothing to update PDF information.");
            }

            string hn = "";

            if (curXCELType == "Access Control") hn = "Access Control";
            if (curXCELType == "CCTV") hn = "Camera";
            else
            {
                MessageBox.Show("Can only update CCTV or Access Control PDF information.");
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


                        DGV_Info.DataSource = null;
                        DGV_Info.Rows.Clear();
                        DGV_Info.Refresh();

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

        /// <summary>
        /// BTN_ReadPDF_Click()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_ReadPDF_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = openFileDialog1.FileName.Trim();

                if ((fn != null) && (fn != ""))
                {
                    myPDFList.Clear();
                    ReadPDFAnnotations(fn);

                    if (myIPAMList.Count > 0)
                        UpdatePDFInfo();

                    if (myPDFList.Count > 0)
                    {
                        var chgdList = myPDFList;

                        DGV_Info.DataSource = null;
                        DGV_Info.Rows.Clear();
                        DGV_Info.Refresh();

                        DGV_Info.DataSource = chgdList;
                        LBL_PDF.Text = "PDF File  Comments";
                    }
                }
                else
                { MessageBox.Show("No file selected"); }
            }
        }

        #endregion

        #region Read Input File - PDFs, CSV (CCTV,Access Control,Thin Clients)
        /// <summary>
        /// ReadPDFAnnotations
        /// </summary>
        /// <param name="PDF"></param>
        private void ReadPDFAnnotations(string PDF)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show("Error :" + e.Message, "Reading file error");
            }
        }

        /// <summary>
        /// ReadIPAMFiles
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
                            //ID = i,
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
        /// DetermineStartLine
        /// </summary>
        /// <returns></returns>
        protected int DetermineStartLine()
        {
            var form4 = new FRM_GetStartLine();
            if (form4.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return FRM_GetStartLine.fileStartLine;
            }
            else
            {
                MessageBox.Show("Action Cancelled");
                return -1;
            }
        }

        /// <summary>
        /// GetHostName
        /// </summary>
        private void GetHostname()
        {
            if ((TBX_File.Text != null) && (TBX_File.Text.Trim() != ""))
            {
                var form2 = new FRM_XCELType();
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myIPAMList.Clear();
                    curXCELType = form2.XCELType;
                }
                else
                {
                    MessageBox.Show("Action Cancelled");
                    curXCELType = "";
                }
            }
            else
            {
                MessageBox.Show("No file selected");
                curXCELType = "";
            }
        }

        /// <summary>
        /// ReadXCELFile()
        /// </summary>
        /// <param name="searchFile"></param>
        /// <param name="type"></param>
        protected void ReadCSVFile(string searchFile, string type)
        {
            try
            {

                string[] lines = System.IO.File.ReadAllLines(searchFile);
                if (lines.Count() <= 0)
                {
                    MessageBox.Show("Cannot process empty file. Please try again.");
                    return;
                }

                int start = DetermineStartLine();
                //System.IO.File.
                if (start == -1)
                {
                    MessageBox.Show("Cannot process file without knowing the first line of data. Please try again.");
                    return;
                }

                //Converts CBS CCTV spreadsheet format to IPAM Import Format
                if (type == "CCTV")
                {
                    for (int i = start; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            myIPAMClass ln = new myIPAMClass { };
                            //ln.ID = i - (start - 1);   //i is current line number
                            ln.IPAddress = cols[6];
                            ln.Status = "Active";
                            ln.Description = cols[1];
                            ln.Hostname = "CCTV";
                            ln.Mac = cols[8];
                            ln.TheSwitch = "";
                            ln.Unknown = "";
                            if (cols[3] == "")
                            {
                                if (cols[2] == "") ln.Port = "";
                                else ln.Port = cols[2].ToUpper();                           //Data
                            }
                            else
                            {
                                if (cols[2] == "") ln.Port = cols[3].ToUpper();             //Switch
                                else ln.Port = (cols[3] + " & " + cols[2]).ToUpper();       //Switch & Data
                            }
                            ln.Note = "";
                            ln.SerialNumber = cols[9];
                            ln.DeviceLocation = cols[1];

                            myIPAMList.Add(ln);
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

                    for (int i = start; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            myIPAMClass ln = new myIPAMClass { };

                            //ln.ID = i - (start - 1);
                            ln.IPAddress = cols[6];
                            ln.Status = "Active";
                            ln.Description = cols[1];
                            ln.Hostname = "Access Control";
                            ln.Mac = cols[7];
                            ln.TheSwitch = "";
                            ln.Unknown = "";

                            if (cols[2] == "")
                            {
                                if (cols[3] == "") ln.Port = "";
                                else ln.Port = cols[3].ToUpper();                           //Data
                            }
                            else
                            {
                                if (cols[3] == "") ln.Port = cols[2].ToUpper();             //Switch
                                else ln.Port = (cols[2] + " & " + cols[3]).ToUpper();       //Switch & Data
                            }
                            //ln.Port = (cols[2] + " & " + cols[3]).ToUpper();        //Switch & Data

                            ln.Note = "";
                            ln.SerialNumber = cols[8];
                            ln.DeviceLocation = cols[1];

                            myIPAMList.Add(ln);
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

                    for (int i = start; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            myIPAMClass ln = new myIPAMClass
                            {
                                //ID = i - (start - 1),
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

                    for (int i = start; i <= (lines.Count() - 1); i++)
                    {
                        string[] cols;
                        string fLine = "";

                        try
                        {
                            fLine = lines[i].ToString();
                            cols = fLine.Split(',');

                            myIPAMClass ln = new myIPAMClass
                            {
                                //ID = i - (start - 1),
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
            var IPAMQry =
                from DataGridViewRow rowView in DGV_Info.Rows
                select rowView;

            PdfReader reader = new PdfReader(inputPath);
            PdfStamper pdfStamper = new PdfStamper(reader, new FileStream(outputPath, FileMode.Create));

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
                        /////
                        if (annot.Get(PdfName.SUBTYPE).Equals(PdfName.FREETEXT))
                        {
                            PdfString comment = annot.GetAsString(PdfName.CONTENTS);
                            PdfString author = annot.GetAsString(PdfName.T);

                            var subj = keys.Find(x => x.ToString() == "/Subj");
                            var subject = annot.Get(subj);

                            if ((author != null) && (author.ToString().Contains("Legend"))) continue;

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
                                            string strEnd = c.Substring(c.IndexOf("C-") + 1);
                                            var stripped = Regex.Replace(strEnd, "[^0-9]", "");

                                            int x;
                                            if (Int32.TryParse(stripped, out x))
                                            {
                                                // you know that the parsing attempt was successful
                                                acNum = x;
                                            }
                                            break;
                                        }
                                    }
                                    if (acNum == 0)
                                    {
                                        MessageBox.Show("Could not get Camera number (C-) from comment. Need Format C-# where # is between 1 and 999");
                                    }
                                    else //Get new string from Grid - New Comment
                                    {
                                        string acIdx = "C-" + acNum.ToString();
                                        int commentNum = 0;

                                        foreach (var row in IPAMQry)
                                        {

                                            string oldCmt = row.Cells[3].Value.ToString();
                                            foreach (string c in oldCmt.Split(' '))
                                            {

                                                if (c.Contains("C-"))
                                                {
                                                    var stripped = Regex.Replace(c, "[^0-9]", "");
                                                    int x;
                                                    if (Int32.TryParse(stripped, out x))
                                                    {
                                                        // you know that the parsing attempt was successful
                                                        commentNum = x;
                                                    }
                                                    break;
                                                }
                                            }
                                            if (commentNum == acNum)
                                            { 
                                                var updateComment = row.Cells[4].Value.ToString();

                                                annot.Put(PdfName.CONTENTS, new PdfString(updateComment.ToString()));
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else
                        /////
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

                                            int x;
                                            if (Int32.TryParse(acNo, out x))
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
                                        var acRow = row.Cells[3].Value.ToString();
                                        if (("AC" + acNum.ToString()) == acRow)
                                        {
                                            var updateComment = row.Cells[4].Value.ToString();

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
                                            string strEnd = c.Substring(c.IndexOf("C-") + 1);
                                            var stripped = Regex.Replace(strEnd, "[^0-9]", "");

                                            int x;
                                            if (Int32.TryParse(stripped, out x))
                                            {
                                                // you know that the parsing attempt was successful
                                                acNum = x;
                                            }
                                            break;
                                        }
                                    }
                                    if (acNum == 0)
                                    {
                                        MessageBox.Show("Could not get Camera number (C-) from comment. Need Format C-# where # is between 1 and 999");
                                    }
                                    else //Get new string from Grid - New Comment
                                    {
                                        string acIdx = "C-" + acNum.ToString();
                                        int commentNum = 0;

                                        foreach (var row in IPAMQry)
                                        {

                                            string oldCmt = row.Cells[3].Value.ToString();
                                            foreach (string c in oldCmt.Split(' '))
                                            {

                                                if (c.Contains("C-"))
                                                {
                                                    var stripped = Regex.Replace(c, "[^0-9]", "");
                                                    int x;
                                                    if (Int32.TryParse(stripped, out x))
                                                    {
                                                        // you know that the parsing attempt was successful
                                                        commentNum = x;
                                                    }
                                                    break;
                                                }
                                            }
                                            if (commentNum == acNum)
                                            {
                                                var updateComment = row.Cells[4].Value.ToString();

                                                annot.Put(PdfName.CONTENTS, new PdfString(updateComment.ToString()));
                                                break;
                                            }
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
        /// UpdatePDFInfo
        /// </summary>
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
                    var desc = row.Cells[2].Value.ToString();   //description field
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

                                int x;
                                if (Int32.TryParse(stripped, out x))
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
                        else //Find in myPDFList - which is created in ReadPDFAnnotations(string PDF)
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

                                        int x;
                                        if (Int32.TryParse(stripped, out x))
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
                                            row.Cells[0].Value.ToString() + "; " +
                                            row.Cells[7].Value.ToString();
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
                    var desc = row.Cells[2].Value.ToString();   //description field
                    if ((desc != null) && (desc.ToString().Contains("AC")))
                    {
                        var cmtSegs = desc.ToString().Split(' ');
                        var acNum = 0;
                        foreach (string c in cmtSegs)
                        {
                            if (c.Contains("AC"))
                            {

                                var stripped = Regex.Replace(c, "[^0-9]", "");

                                int x;
                                if (Int32.TryParse(stripped, out x))
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
                        else //Find in myPDFList - which is created in ReadPDFAnnotations(string PDF)
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

                                        int x;
                                        if (Int32.TryParse(stripped, out x))
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
                                            row.Cells[0].Value.ToString() + "; " +
                                            row.Cells[7].Value.ToString();
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
                        string s = (row.Cells[i].Value == null) ? "" : row.Cells[i].Value.ToString();
                        if (i == 1)
                            outLine = s;
                        else
                            outLine = outLine + "," + s;
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
    }
}