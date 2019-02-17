namespace PDF_app
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TabPage TPG_XCEL;
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTN_NewPDF = new System.Windows.Forms.Button();
            this.BTN_UpdatePDF = new System.Windows.Forms.Button();
            this.BTN_SaveIPAM = new System.Windows.Forms.Button();
            this.BTN_ProcessXCEL = new System.Windows.Forms.Button();
            this.LBX_XCELList = new System.Windows.Forms.ListBox();
            this.TBX_XCELFile = new System.Windows.Forms.TextBox();
            this.LBL_SelectXcel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TPG_PDF = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_ProcessPDF = new System.Windows.Forms.Button();
            this.LBX_PDFList = new System.Windows.Forms.ListBox();
            this.TBX_PDFFile = new System.Windows.Forms.TextBox();
            this.LBL_SelectPDF = new System.Windows.Forms.Label();
            this.BTN_ChangeDir = new System.Windows.Forms.Button();
            this.LBLCurDirInfo = new System.Windows.Forms.Label();
            this.LBLCurDir = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV_Info = new System.Windows.Forms.DataGridView();
            this.LBL_PDF = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            TPG_XCEL = new System.Windows.Forms.TabPage();
            TPG_XCEL.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TPG_PDF.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // TPG_XCEL
            // 
            TPG_XCEL.Controls.Add(this.panel4);
            TPG_XCEL.Location = new System.Drawing.Point(4, 22);
            TPG_XCEL.Name = "TPG_XCEL";
            TPG_XCEL.Padding = new System.Windows.Forms.Padding(3);
            TPG_XCEL.Size = new System.Drawing.Size(1270, 136);
            TPG_XCEL.TabIndex = 1;
            TPG_XCEL.Text = "EXCEL files";
            TPG_XCEL.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.BTN_NewPDF);
            this.panel4.Controls.Add(this.BTN_UpdatePDF);
            this.panel4.Controls.Add(this.BTN_SaveIPAM);
            this.panel4.Controls.Add(this.BTN_ProcessXCEL);
            this.panel4.Controls.Add(this.LBX_XCELList);
            this.panel4.Controls.Add(this.TBX_XCELFile);
            this.panel4.Controls.Add(this.LBL_SelectXcel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1264, 130);
            this.panel4.TabIndex = 0;
            // 
            // BTN_NewPDF
            // 
            this.BTN_NewPDF.Location = new System.Drawing.Point(815, 4);
            this.BTN_NewPDF.Name = "BTN_NewPDF";
            this.BTN_NewPDF.Size = new System.Drawing.Size(162, 23);
            this.BTN_NewPDF.TabIndex = 31;
            this.BTN_NewPDF.Text = "Create New Updated PDF";
            this.BTN_NewPDF.UseVisualStyleBackColor = true;
            this.BTN_NewPDF.Visible = false;
            this.BTN_NewPDF.Click += new System.EventHandler(this.BTN_NewPDF_Click);
            // 
            // BTN_UpdatePDF
            // 
            this.BTN_UpdatePDF.Location = new System.Drawing.Point(621, 4);
            this.BTN_UpdatePDF.Name = "BTN_UpdatePDF";
            this.BTN_UpdatePDF.Size = new System.Drawing.Size(188, 23);
            this.BTN_UpdatePDF.TabIndex = 30;
            this.BTN_UpdatePDF.Text = "Update PDF file";
            this.BTN_UpdatePDF.UseVisualStyleBackColor = true;
            this.BTN_UpdatePDF.Visible = false;
            this.BTN_UpdatePDF.Click += new System.EventHandler(this.BTN_UpdatePDF_Click);
            // 
            // BTN_SaveIPAM
            // 
            this.BTN_SaveIPAM.Location = new System.Drawing.Point(426, 32);
            this.BTN_SaveIPAM.Name = "BTN_SaveIPAM";
            this.BTN_SaveIPAM.Size = new System.Drawing.Size(189, 23);
            this.BTN_SaveIPAM.TabIndex = 29;
            this.BTN_SaveIPAM.Text = "Save Grid as IPAM Import file";
            this.BTN_SaveIPAM.UseVisualStyleBackColor = true;
            this.BTN_SaveIPAM.Visible = false;
            this.BTN_SaveIPAM.Click += new System.EventHandler(this.BTN_SaveIPAM_Click);
            // 
            // BTN_ProcessXCEL
            // 
            this.BTN_ProcessXCEL.Location = new System.Drawing.Point(426, 4);
            this.BTN_ProcessXCEL.Name = "BTN_ProcessXCEL";
            this.BTN_ProcessXCEL.Size = new System.Drawing.Size(189, 22);
            this.BTN_ProcessXCEL.TabIndex = 28;
            this.BTN_ProcessXCEL.Text = "ShowSelected File as IPAM File";
            this.BTN_ProcessXCEL.UseVisualStyleBackColor = true;
            this.BTN_ProcessXCEL.Click += new System.EventHandler(this.BTNProcessFillDGV_Click);
            // 
            // LBX_XCELList
            // 
            this.LBX_XCELList.FormattingEnabled = true;
            this.LBX_XCELList.Location = new System.Drawing.Point(8, 32);
            this.LBX_XCELList.Name = "LBX_XCELList";
            this.LBX_XCELList.Size = new System.Drawing.Size(412, 95);
            this.LBX_XCELList.TabIndex = 27;
            this.LBX_XCELList.SelectedIndexChanged += new System.EventHandler(this.LBX_PDFList_SelectedValueChanged);
            // 
            // TBX_XCELFile
            // 
            this.TBX_XCELFile.Location = new System.Drawing.Point(141, 6);
            this.TBX_XCELFile.Name = "TBX_XCELFile";
            this.TBX_XCELFile.Size = new System.Drawing.Size(279, 20);
            this.TBX_XCELFile.TabIndex = 26;
            // 
            // LBL_SelectXcel
            // 
            this.LBL_SelectXcel.AutoSize = true;
            this.LBL_SelectXcel.Location = new System.Drawing.Point(5, 9);
            this.LBL_SelectXcel.Name = "LBL_SelectXcel";
            this.LBL_SelectXcel.Size = new System.Drawing.Size(136, 13);
            this.LBL_SelectXcel.TabIndex = 25;
            this.LBL_SelectXcel.Text = "Selected EXCEL File Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.BTN_ChangeDir);
            this.panel1.Controls.Add(this.LBLCurDirInfo);
            this.panel1.Controls.Add(this.LBLCurDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 195);
            this.panel1.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(TPG_XCEL);
            this.tabControl1.Controls.Add(this.TPG_PDF);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1278, 162);
            this.tabControl1.TabIndex = 27;
            // 
            // TPG_PDF
            // 
            this.TPG_PDF.Controls.Add(this.panel3);
            this.TPG_PDF.Location = new System.Drawing.Point(4, 22);
            this.TPG_PDF.Name = "TPG_PDF";
            this.TPG_PDF.Padding = new System.Windows.Forms.Padding(3);
            this.TPG_PDF.Size = new System.Drawing.Size(1270, 136);
            this.TPG_PDF.TabIndex = 0;
            this.TPG_PDF.Text = "PDF files";
            this.TPG_PDF.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.BTN_ProcessPDF);
            this.panel3.Controls.Add(this.LBX_PDFList);
            this.panel3.Controls.Add(this.TBX_PDFFile);
            this.panel3.Controls.Add(this.LBL_SelectPDF);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1264, 130);
            this.panel3.TabIndex = 1;
            // 
            // BTN_ProcessPDF
            // 
            this.BTN_ProcessPDF.Location = new System.Drawing.Point(430, 4);
            this.BTN_ProcessPDF.Name = "BTN_ProcessPDF";
            this.BTN_ProcessPDF.Size = new System.Drawing.Size(162, 23);
            this.BTN_ProcessPDF.TabIndex = 29;
            this.BTN_ProcessPDF.Text = "Show PDF Annotation Info";
            this.BTN_ProcessPDF.UseVisualStyleBackColor = true;
            this.BTN_ProcessPDF.Click += new System.EventHandler(this.BTNProcessFillDGV_Click);
            // 
            // LBX_PDFList
            // 
            this.LBX_PDFList.FormattingEnabled = true;
            this.LBX_PDFList.Location = new System.Drawing.Point(8, 32);
            this.LBX_PDFList.Name = "LBX_PDFList";
            this.LBX_PDFList.Size = new System.Drawing.Size(412, 95);
            this.LBX_PDFList.TabIndex = 28;
            this.LBX_PDFList.SelectedIndexChanged += new System.EventHandler(this.LBX_PDFList_SelectedValueChanged);
            // 
            // TBX_PDFFile
            // 
            this.TBX_PDFFile.Location = new System.Drawing.Point(134, 6);
            this.TBX_PDFFile.Name = "TBX_PDFFile";
            this.TBX_PDFFile.Size = new System.Drawing.Size(286, 20);
            this.TBX_PDFFile.TabIndex = 27;
            // 
            // LBL_SelectPDF
            // 
            this.LBL_SelectPDF.AutoSize = true;
            this.LBL_SelectPDF.Location = new System.Drawing.Point(5, 9);
            this.LBL_SelectPDF.Name = "LBL_SelectPDF";
            this.LBL_SelectPDF.Size = new System.Drawing.Size(123, 13);
            this.LBL_SelectPDF.TabIndex = 26;
            this.LBL_SelectPDF.Text = "Selected PDF File Name";
            // 
            // BTN_ChangeDir
            // 
            this.BTN_ChangeDir.Location = new System.Drawing.Point(15, 4);
            this.BTN_ChangeDir.Name = "BTN_ChangeDir";
            this.BTN_ChangeDir.Size = new System.Drawing.Size(206, 23);
            this.BTN_ChangeDir.TabIndex = 11;
            this.BTN_ChangeDir.Text = "Change Current Directory";
            this.BTN_ChangeDir.UseVisualStyleBackColor = true;
            this.BTN_ChangeDir.Click += new System.EventHandler(this.BTN_ChangeDir_Click);
            // 
            // LBLCurDirInfo
            // 
            this.LBLCurDirInfo.AutoSize = true;
            this.LBLCurDirInfo.Location = new System.Drawing.Point(319, 14);
            this.LBLCurDirInfo.Name = "LBLCurDirInfo";
            this.LBLCurDirInfo.Size = new System.Drawing.Size(64, 13);
            this.LBLCurDirInfo.TabIndex = 9;
            this.LBLCurDirInfo.Text = "curDirectory";
            // 
            // LBLCurDir
            // 
            this.LBLCurDir.AutoSize = true;
            this.LBLCurDir.Location = new System.Drawing.Point(227, 14);
            this.LBLCurDir.Name = "LBLCurDir";
            this.LBLCurDir.Size = new System.Drawing.Size(86, 13);
            this.LBLCurDir.TabIndex = 8;
            this.LBLCurDir.Text = "Current Directory";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGV_Info);
            this.panel2.Controls.Add(this.LBL_PDF);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1278, 378);
            this.panel2.TabIndex = 8;
            // 
            // DGV_Info
            // 
            this.DGV_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Info.Location = new System.Drawing.Point(0, 22);
            this.DGV_Info.Name = "DGV_Info";
            this.DGV_Info.Size = new System.Drawing.Size(1278, 356);
            this.DGV_Info.TabIndex = 14;
            // 
            // LBL_PDF
            // 
            this.LBL_PDF.Dock = System.Windows.Forms.DockStyle.Top;
            this.LBL_PDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PDF.Location = new System.Drawing.Point(0, 0);
            this.LBL_PDF.Name = "LBL_PDF";
            this.LBL_PDF.Size = new System.Drawing.Size(1278, 22);
            this.LBL_PDF.TabIndex = 15;
            this.LBL_PDF.Text = "PDF File Information";
            this.LBL_PDF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "IPAM Import Files (*.csv)|*.csv";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "pdf";
            this.openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            TPG_XCEL.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TPG_PDF.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBLCurDirInfo;
        private System.Windows.Forms.Label LBLCurDir;
        private System.Windows.Forms.Button BTN_ChangeDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LBL_PDF;
        private System.Windows.Forms.DataGridView DGV_Info;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TPG_PDF;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTN_ProcessPDF;
        private System.Windows.Forms.ListBox LBX_PDFList;
        private System.Windows.Forms.TextBox TBX_PDFFile;
        private System.Windows.Forms.Label LBL_SelectPDF;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BTN_SaveIPAM;
        private System.Windows.Forms.Button BTN_ProcessXCEL;
        private System.Windows.Forms.ListBox LBX_XCELList;
        private System.Windows.Forms.TextBox TBX_XCELFile;
        private System.Windows.Forms.Label LBL_SelectXcel;
        private System.Windows.Forms.Button BTN_UpdatePDF;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BTN_NewPDF;
    }
}

