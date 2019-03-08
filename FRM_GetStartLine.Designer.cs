namespace PDF_app
{
    partial class FRM_GetStartLine
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
            this.BTN_GetPrevious = new System.Windows.Forms.Button();
            this.BTN_NextLine = new System.Windows.Forms.Button();
            this.LBL_FileLine = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTN_Okay = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTN_GetPrevious);
            this.panel1.Controls.Add(this.BTN_NextLine);
            this.panel1.Controls.Add(this.LBL_FileLine);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 193);
            this.panel1.TabIndex = 0;
            // 
            // BTN_GetPrevious
            // 
            this.BTN_GetPrevious.Location = new System.Drawing.Point(117, 78);
            this.BTN_GetPrevious.Name = "BTN_GetPrevious";
            this.BTN_GetPrevious.Size = new System.Drawing.Size(105, 23);
            this.BTN_GetPrevious.TabIndex = 3;
            this.BTN_GetPrevious.Text = "Get Previous Line";
            this.BTN_GetPrevious.UseVisualStyleBackColor = true;
            this.BTN_GetPrevious.Click += new System.EventHandler(this.BTN_GetPrevious_Click);
            // 
            // BTN_NextLine
            // 
            this.BTN_NextLine.Location = new System.Drawing.Point(16, 78);
            this.BTN_NextLine.Name = "BTN_NextLine";
            this.BTN_NextLine.Size = new System.Drawing.Size(95, 23);
            this.BTN_NextLine.TabIndex = 2;
            this.BTN_NextLine.Text = "Get Next Line";
            this.BTN_NextLine.UseVisualStyleBackColor = true;
            this.BTN_NextLine.Click += new System.EventHandler(this.BTN_NextLine_Click);
            // 
            // LBL_FileLine
            // 
            this.LBL_FileLine.BackColor = System.Drawing.SystemColors.Window;
            this.LBL_FileLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FileLine.Location = new System.Drawing.Point(16, 41);
            this.LBL_FileLine.Name = "LBL_FileLine";
            this.LBL_FileLine.Size = new System.Drawing.Size(490, 22);
            this.LBL_FileLine.TabIndex = 1;
            this.LBL_FileLine.Text = "LBL_FileLine";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click Okay button when line is the first to process";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTN_Okay);
            this.panel2.Controls.Add(this.BTN_Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 40);
            this.panel2.TabIndex = 1;
            // 
            // BTN_Okay
            // 
            this.BTN_Okay.Location = new System.Drawing.Point(364, 5);
            this.BTN_Okay.Name = "BTN_Okay";
            this.BTN_Okay.Size = new System.Drawing.Size(75, 23);
            this.BTN_Okay.TabIndex = 5;
            this.BTN_Okay.Text = "Okay";
            this.BTN_Okay.UseVisualStyleBackColor = true;
            this.BTN_Okay.Click += new System.EventHandler(this.BTN_Okay_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(445, 5);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.TabIndex = 4;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // FRM_GetStartLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 193);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FRM_GetStartLine";
            this.Text = "FRM_GetStartLine";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTN_Okay;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Label LBL_FileLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_NextLine;
        private System.Windows.Forms.Button BTN_GetPrevious;
    }
}