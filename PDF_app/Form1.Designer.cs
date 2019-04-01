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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CBX_FileType = new System.Windows.Forms.ComboBox();
            this.BTN_Mapping = new System.Windows.Forms.Button();
            this.BTN_NewPDF = new System.Windows.Forms.Button();
            this.BTN_UpdatePDF = new System.Windows.Forms.Button();
            this.BTN_SaveIPAM = new System.Windows.Forms.Button();
            this.BTN_ProcessXCEL = new System.Windows.Forms.Button();
            this.LBX_FileList = new System.Windows.Forms.ListBox();
            this.TBX_File = new System.Windows.Forms.TextBox();
            this.LBL_SelectXcel = new System.Windows.Forms.Label();
            this.BTN_ChangeDir = new System.Windows.Forms.Button();
            this.LBLCurDirInfo = new System.Windows.Forms.Label();
            this.LBLCurDir = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV_Info = new System.Windows.Forms.DataGridView();
            this.LBL_PDF = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.BTN_ChangeDir);
            this.panel1.Controls.Add(this.LBLCurDirInfo);
            this.panel1.Controls.Add(this.LBLCurDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 192);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.CBX_FileType);
            this.panel4.Controls.Add(this.BTN_Mapping);
            this.panel4.Controls.Add(this.BTN_NewPDF);
            this.panel4.Controls.Add(this.BTN_UpdatePDF);
            this.panel4.Controls.Add(this.BTN_SaveIPAM);
            this.panel4.Controls.Add(this.BTN_ProcessXCEL);
            this.panel4.Controls.Add(this.LBX_FileList);
            this.panel4.Controls.Add(this.TBX_File);
            this.panel4.Controls.Add(this.LBL_SelectXcel);
            this.panel4.Location = new System.Drawing.Point(12, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1264, 156);
            this.panel4.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Select File Type";
            // 
            // CBX_FileType
            // 
            this.CBX_FileType.FormattingEnabled = true;
            this.CBX_FileType.Items.AddRange(new object[] {
            "Excel  - CSV",
            "Plans - PDF"});
            this.CBX_FileType.Location = new System.Drawing.Point(13, 32);
            this.CBX_FileType.Name = "CBX_FileType";
            this.CBX_FileType.Size = new System.Drawing.Size(121, 21);
            this.CBX_FileType.TabIndex = 33;
            this.CBX_FileType.Text = "Excel - CSV";
            this.CBX_FileType.SelectedValueChanged += new System.EventHandler(this.CBX_FileType_SelectedValueChanged);
            // 
            // BTN_Mapping
            // 
            this.BTN_Mapping.Location = new System.Drawing.Point(575, 61);
            this.BTN_Mapping.Name = "BTN_Mapping";
            this.BTN_Mapping.Size = new System.Drawing.Size(189, 23);
            this.BTN_Mapping.TabIndex = 32;
            this.BTN_Mapping.Text = "Create File Mapping ";
            this.BTN_Mapping.UseVisualStyleBackColor = true;
            this.BTN_Mapping.Click += new System.EventHandler(this.BTN_Mapping_Click);
            // 
            // BTN_NewPDF
            // 
            this.BTN_NewPDF.Location = new System.Drawing.Point(770, 4);
            this.BTN_NewPDF.Name = "BTN_NewPDF";
            this.BTN_NewPDF.Size = new System.Drawing.Size(162, 23);
            this.BTN_NewPDF.TabIndex = 31;
            this.BTN_NewPDF.Text = "Create New Updated PDF";
            this.BTN_NewPDF.UseVisualStyleBackColor = true;
            this.BTN_NewPDF.Click += new System.EventHandler(this.BTN_NewPDF_Click);
            // 
            // BTN_UpdatePDF
            // 
            this.BTN_UpdatePDF.Location = new System.Drawing.Point(770, 30);
            this.BTN_UpdatePDF.Name = "BTN_UpdatePDF";
            this.BTN_UpdatePDF.Size = new System.Drawing.Size(162, 23);
            this.BTN_UpdatePDF.TabIndex = 30;
            this.BTN_UpdatePDF.Text = "Update PDF File";
            this.BTN_UpdatePDF.UseVisualStyleBackColor = true;
            this.BTN_UpdatePDF.Visible = false;
            this.BTN_UpdatePDF.Click += new System.EventHandler(this.BTN_UpdatePDF_Click);
            // 
            // BTN_SaveIPAM
            // 
            this.BTN_SaveIPAM.Location = new System.Drawing.Point(575, 32);
            this.BTN_SaveIPAM.Name = "BTN_SaveIPAM";
            this.BTN_SaveIPAM.Size = new System.Drawing.Size(189, 23);
            this.BTN_SaveIPAM.TabIndex = 29;
            this.BTN_SaveIPAM.Text = "Save Grid as IPAM Import File";
            this.BTN_SaveIPAM.UseVisualStyleBackColor = true;
            this.BTN_SaveIPAM.Visible = false;
            this.BTN_SaveIPAM.Click += new System.EventHandler(this.BTN_SaveIPAM_Click);
            // 
            // BTN_ProcessXCEL
            // 
            this.BTN_ProcessXCEL.Location = new System.Drawing.Point(575, 4);
            this.BTN_ProcessXCEL.Name = "BTN_ProcessXCEL";
            this.BTN_ProcessXCEL.Size = new System.Drawing.Size(189, 22);
            this.BTN_ProcessXCEL.TabIndex = 28;
            this.BTN_ProcessXCEL.Text = "ShowSelected File as IPAM File";
            this.BTN_ProcessXCEL.UseVisualStyleBackColor = true;
            this.BTN_ProcessXCEL.Click += new System.EventHandler(this.BTNProcessFillDGV_Click);
            // 
            // LBX_FileList
            // 
            this.LBX_FileList.FormattingEnabled = true;
            this.LBX_FileList.Location = new System.Drawing.Point(157, 32);
            this.LBX_FileList.Name = "LBX_FileList";
            this.LBX_FileList.Size = new System.Drawing.Size(412, 108);
            this.LBX_FileList.TabIndex = 27;
            this.LBX_FileList.SelectedValueChanged += new System.EventHandler(this.LBX_FileList_SelectedValueChanged);
            // 
            // TBX_File
            // 
            this.TBX_File.Location = new System.Drawing.Point(259, 6);
            this.TBX_File.Name = "TBX_File";
            this.TBX_File.Size = new System.Drawing.Size(310, 20);
            this.TBX_File.TabIndex = 26;
            // 
            // LBL_SelectXcel
            // 
            this.LBL_SelectXcel.AutoSize = true;
            this.LBL_SelectXcel.Location = new System.Drawing.Point(154, 9);
            this.LBL_SelectXcel.Name = "LBL_SelectXcel";
            this.LBL_SelectXcel.Size = new System.Drawing.Size(99, 13);
            this.LBL_SelectXcel.TabIndex = 25;
            this.LBL_SelectXcel.Text = "Selected File Name";
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
            this.panel2.Location = new System.Drawing.Point(0, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1278, 381);
            this.panel2.TabIndex = 8;
            // 
            // DGV_Info
            // 
            this.DGV_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Info.Location = new System.Drawing.Point(0, 22);
            this.DGV_Info.Name = "DGV_Info";
            this.DGV_Info.Size = new System.Drawing.Size(1278, 359);
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
            this.LBL_PDF.Text = "File Information";
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BTN_Mapping;
        private System.Windows.Forms.Button BTN_NewPDF;
        private System.Windows.Forms.Button BTN_UpdatePDF;
        private System.Windows.Forms.Button BTN_SaveIPAM;
        private System.Windows.Forms.Button BTN_ProcessXCEL;
        private System.Windows.Forms.ListBox LBX_FileList;
        private System.Windows.Forms.TextBox TBX_File;
        private System.Windows.Forms.Label LBL_SelectXcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBX_FileType;
    }
}

