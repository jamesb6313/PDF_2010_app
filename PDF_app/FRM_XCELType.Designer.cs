namespace PDF_app
{
    partial class FRM_XCELType
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
            this.BTN_Okay = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.LBX_Types = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBX_Type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTN_Okay);
            this.panel1.Controls.Add(this.BTN_Cancel);
            this.panel1.Controls.Add(this.LBX_Types);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 283);
            this.panel1.TabIndex = 0;
            // 
            // BTN_Okay
            // 
            this.BTN_Okay.Location = new System.Drawing.Point(67, 257);
            this.BTN_Okay.Name = "BTN_Okay";
            this.BTN_Okay.Size = new System.Drawing.Size(75, 23);
            this.BTN_Okay.TabIndex = 3;
            this.BTN_Okay.Text = "Okay";
            this.BTN_Okay.UseVisualStyleBackColor = true;
            this.BTN_Okay.Click += new System.EventHandler(this.BTN_Okay_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(148, 257);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.TabIndex = 2;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // LBX_Types
            // 
            this.LBX_Types.Dock = System.Windows.Forms.DockStyle.Top;
            this.LBX_Types.FormattingEnabled = true;
            this.LBX_Types.Location = new System.Drawing.Point(0, 41);
            this.LBX_Types.Name = "LBX_Types";
            this.LBX_Types.Size = new System.Drawing.Size(313, 199);
            this.LBX_Types.TabIndex = 1;
            this.LBX_Types.SelectedIndexChanged += new System.EventHandler(this.LBX_Types_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TBX_Type);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 41);
            this.panel2.TabIndex = 0;
            // 
            // TBX_Type
            // 
            this.TBX_Type.Dock = System.Windows.Forms.DockStyle.Right;
            this.TBX_Type.Location = new System.Drawing.Point(171, 0);
            this.TBX_Type.Name = "TBX_Type";
            this.TBX_Type.Size = new System.Drawing.Size(142, 20);
            this.TBX_Type.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Type:";
            // 
            // FRM_XCELType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 283);
            this.Controls.Add(this.panel1);
            this.Name = "FRM_XCELType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select CSV File Type (CCTV,AC,..)";
            this.Load += new System.EventHandler(this.FRM_XCELType_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_Okay;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.ListBox LBX_Types;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TBX_Type;
        private System.Windows.Forms.Label label1;
    }
}