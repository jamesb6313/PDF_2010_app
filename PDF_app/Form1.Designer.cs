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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_NewPDF = new System.Windows.Forms.Button();
            this.BTN_SaveIPAM = new System.Windows.Forms.Button();
            this.BTN_ProcessXCEL = new System.Windows.Forms.Button();
            this.BTN_ProcessPDF = new System.Windows.Forms.Button();
            this.LBX_XCELList = new System.Windows.Forms.ListBox();
            this.TBX_XCELFile = new System.Windows.Forms.TextBox();
            this.LBL_SelectXcel = new System.Windows.Forms.Label();
            this.BTNChangeDir = new System.Windows.Forms.Button();
            this.LBX_PDFList = new System.Windows.Forms.ListBox();
            this.LBLCurDirInfo = new System.Windows.Forms.Label();
            this.LBLCurDir = new System.Windows.Forms.Label();
            this.TBX_PDFFile = new System.Windows.Forms.TextBox();
            this.LBL_SelectPDF = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV_Info = new System.Windows.Forms.DataGridView();
            this.LBL_PDF = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTN_NewPDF);
            this.panel1.Controls.Add(this.BTN_SaveIPAM);
            this.panel1.Controls.Add(this.BTN_ProcessXCEL);
            this.panel1.Controls.Add(this.BTN_ProcessPDF);
            this.panel1.Controls.Add(this.LBX_XCELList);
            this.panel1.Controls.Add(this.TBX_XCELFile);
            this.panel1.Controls.Add(this.LBL_SelectXcel);
            this.panel1.Controls.Add(this.BTNChangeDir);
            this.panel1.Controls.Add(this.LBX_PDFList);
            this.panel1.Controls.Add(this.LBLCurDirInfo);
            this.panel1.Controls.Add(this.LBLCurDir);
            this.panel1.Controls.Add(this.TBX_PDFFile);
            this.panel1.Controls.Add(this.LBL_SelectPDF);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 195);
            this.panel1.TabIndex = 7;
            // 
            // BTN_NewPDF
            // 
            this.BTN_NewPDF.Location = new System.Drawing.Point(204, 164);
            this.BTN_NewPDF.Name = "BTN_NewPDF";
            this.BTN_NewPDF.Size = new System.Drawing.Size(172, 23);
            this.BTN_NewPDF.TabIndex = 25;
            this.BTN_NewPDF.Text = "Create New Updated PDF";
            this.BTN_NewPDF.UseVisualStyleBackColor = true;
            this.BTN_NewPDF.Click += new System.EventHandler(this.BTN_NewPDF_Click);
            // 
            // BTN_SaveIPAM
            // 
            this.BTN_SaveIPAM.Location = new System.Drawing.Point(634, 166);
            this.BTN_SaveIPAM.Name = "BTN_SaveIPAM";
            this.BTN_SaveIPAM.Size = new System.Drawing.Size(195, 23);
            this.BTN_SaveIPAM.TabIndex = 24;
            this.BTN_SaveIPAM.Text = "Save Grid as IPAM Import file";
            this.BTN_SaveIPAM.UseVisualStyleBackColor = true;
            this.BTN_SaveIPAM.Click += new System.EventHandler(this.BTN_SaveIPAM_Click);
            // 
            // BTN_ProcessXCEL
            // 
            this.BTN_ProcessXCEL.Location = new System.Drawing.Point(417, 164);
            this.BTN_ProcessXCEL.Name = "BTN_ProcessXCEL";
            this.BTN_ProcessXCEL.Size = new System.Drawing.Size(189, 23);
            this.BTN_ProcessXCEL.TabIndex = 20;
            this.BTN_ProcessXCEL.Text = "ShowSelected File as IPAM File";
            this.BTN_ProcessXCEL.UseVisualStyleBackColor = true;
            this.BTN_ProcessXCEL.Click += new System.EventHandler(this.BTNProcessFillDGV_Click);
            // 
            // BTN_ProcessPDF
            // 
            this.BTN_ProcessPDF.Location = new System.Drawing.Point(15, 164);
            this.BTN_ProcessPDF.Name = "BTN_ProcessPDF";
            this.BTN_ProcessPDF.Size = new System.Drawing.Size(162, 23);
            this.BTN_ProcessPDF.TabIndex = 19;
            this.BTN_ProcessPDF.Text = "Show PDF Annotation Info";
            this.BTN_ProcessPDF.UseVisualStyleBackColor = true;
            this.BTN_ProcessPDF.Click += new System.EventHandler(this.BTNProcessFillDGV_Click);
            // 
            // LBX_XCELList
            // 
            this.LBX_XCELList.FormattingEnabled = true;
            this.LBX_XCELList.Location = new System.Drawing.Point(417, 63);
            this.LBX_XCELList.Name = "LBX_XCELList";
            this.LBX_XCELList.Size = new System.Drawing.Size(412, 95);
            this.LBX_XCELList.TabIndex = 14;
            this.LBX_XCELList.SelectedIndexChanged += new System.EventHandler(this.LBX_PDFList_SelectedValueChanged);
            // 
            // TBX_XCELFile
            // 
            this.TBX_XCELFile.Location = new System.Drawing.Point(585, 37);
            this.TBX_XCELFile.Name = "TBX_XCELFile";
            this.TBX_XCELFile.Size = new System.Drawing.Size(244, 20);
            this.TBX_XCELFile.TabIndex = 13;
            // 
            // LBL_SelectXcel
            // 
            this.LBL_SelectXcel.AutoSize = true;
            this.LBL_SelectXcel.Location = new System.Drawing.Point(465, 40);
            this.LBL_SelectXcel.Name = "LBL_SelectXcel";
            this.LBL_SelectXcel.Size = new System.Drawing.Size(117, 13);
            this.LBL_SelectXcel.TabIndex = 12;
            this.LBL_SelectXcel.Text = "Select XCEL File Name";
            // 
            // BTNChangeDir
            // 
            this.BTNChangeDir.Location = new System.Drawing.Point(15, 4);
            this.BTNChangeDir.Name = "BTNChangeDir";
            this.BTNChangeDir.Size = new System.Drawing.Size(206, 23);
            this.BTNChangeDir.TabIndex = 11;
            this.BTNChangeDir.Text = "Change Current Directory";
            this.BTNChangeDir.UseVisualStyleBackColor = true;
            this.BTNChangeDir.Click += new System.EventHandler(this.BTNChangeDir_Click);
            // 
            // LBX_PDFList
            // 
            this.LBX_PDFList.FormattingEnabled = true;
            this.LBX_PDFList.Location = new System.Drawing.Point(15, 63);
            this.LBX_PDFList.Name = "LBX_PDFList";
            this.LBX_PDFList.Size = new System.Drawing.Size(361, 95);
            this.LBX_PDFList.TabIndex = 10;
            this.LBX_PDFList.SelectedIndexChanged += new System.EventHandler(this.LBX_PDFList_SelectedValueChanged);
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
            // TBX_PDFFile
            // 
            this.TBX_PDFFile.Location = new System.Drawing.Point(132, 37);
            this.TBX_PDFFile.Name = "TBX_PDFFile";
            this.TBX_PDFFile.Size = new System.Drawing.Size(244, 20);
            this.TBX_PDFFile.TabIndex = 7;
            // 
            // LBL_SelectPDF
            // 
            this.LBL_SelectPDF.AutoSize = true;
            this.LBL_SelectPDF.Location = new System.Drawing.Point(12, 40);
            this.LBL_SelectPDF.Name = "LBL_SelectPDF";
            this.LBL_SelectPDF.Size = new System.Drawing.Size(111, 13);
            this.LBL_SelectPDF.TabIndex = 6;
            this.LBL_SelectPDF.Text = "Select PDF File Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGV_Info);
            this.panel2.Controls.Add(this.LBL_PDF);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1278, 319);
            this.panel2.TabIndex = 8;
            // 
            // DGV_Info
            // 
            this.DGV_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Info.Location = new System.Drawing.Point(0, 18);
            this.DGV_Info.Name = "DGV_Info";
            this.DGV_Info.Size = new System.Drawing.Size(1278, 301);
            this.DGV_Info.TabIndex = 14;
            // 
            // LBL_PDF
            // 
            this.LBL_PDF.Dock = System.Windows.Forms.DockStyle.Top;
            this.LBL_PDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PDF.Location = new System.Drawing.Point(0, 0);
            this.LBL_PDF.Name = "LBL_PDF";
            this.LBL_PDF.Size = new System.Drawing.Size(1278, 18);
            this.LBL_PDF.TabIndex = 15;
            this.LBL_PDF.Text = "PDF File Information";
            this.LBL_PDF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "IPAM Import Files (*.csv)|*.csv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Convert CBS Spreadsheets into IPAM Iport files";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 514);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox LBX_PDFList;
        private System.Windows.Forms.Label LBLCurDirInfo;
        private System.Windows.Forms.Label LBLCurDir;
        private System.Windows.Forms.TextBox TBX_PDFFile;
        private System.Windows.Forms.Label LBL_SelectPDF;
        private System.Windows.Forms.Button BTNChangeDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox LBX_XCELList;
        private System.Windows.Forms.TextBox TBX_XCELFile;
        private System.Windows.Forms.Label LBL_SelectXcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LBL_PDF;
        private System.Windows.Forms.DataGridView DGV_Info;
        private System.Windows.Forms.Button BTN_ProcessXCEL;
        private System.Windows.Forms.Button BTN_ProcessPDF;
        private System.Windows.Forms.Button BTN_SaveIPAM;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button BTN_NewPDF;
        private System.Windows.Forms.Label label1;
    }
}

