namespace PDF_app
{
    partial class FRM_FieldSelections
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
            this.LBX_AllFields = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LBX_Selected = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_SelectedLeft = new System.Windows.Forms.Button();
            this.BTN_AllLeft = new System.Windows.Forms.Button();
            this.BTN_SelectedRight = new System.Windows.Forms.Button();
            this.BTN_AllRight = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBX_AllFields);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 450);
            this.panel1.TabIndex = 0;
            // 
            // LBX_AllFields
            // 
            this.LBX_AllFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBX_AllFields.FormattingEnabled = true;
            this.LBX_AllFields.Location = new System.Drawing.Point(0, 0);
            this.LBX_AllFields.Name = "LBX_AllFields";
            this.LBX_AllFields.Size = new System.Drawing.Size(270, 450);
            this.LBX_AllFields.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LBX_Selected);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(535, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 450);
            this.panel2.TabIndex = 1;
            // 
            // LBX_Selected
            // 
            this.LBX_Selected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBX_Selected.FormattingEnabled = true;
            this.LBX_Selected.Location = new System.Drawing.Point(0, 0);
            this.LBX_Selected.Name = "LBX_Selected";
            this.LBX_Selected.Size = new System.Drawing.Size(265, 450);
            this.LBX_Selected.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(270, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 450);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTN_SelectedLeft);
            this.groupBox1.Controls.Add(this.BTN_AllLeft);
            this.groupBox1.Controls.Add(this.BTN_SelectedRight);
            this.groupBox1.Controls.Add(this.BTN_AllRight);
            this.groupBox1.Location = new System.Drawing.Point(68, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Make Selections";
            // 
            // BTN_SelectedLeft
            // 
            this.BTN_SelectedLeft.Location = new System.Drawing.Point(7, 130);
            this.BTN_SelectedLeft.Name = "BTN_SelectedLeft";
            this.BTN_SelectedLeft.Size = new System.Drawing.Size(92, 23);
            this.BTN_SelectedLeft.TabIndex = 3;
            this.BTN_SelectedLeft.Text = "<";
            this.BTN_SelectedLeft.UseVisualStyleBackColor = true;
            this.BTN_SelectedLeft.Click += new System.EventHandler(this.BTN_SelectedLeft_Click);
            // 
            // BTN_AllLeft
            // 
            this.BTN_AllLeft.Location = new System.Drawing.Point(7, 100);
            this.BTN_AllLeft.Name = "BTN_AllLeft";
            this.BTN_AllLeft.Size = new System.Drawing.Size(92, 23);
            this.BTN_AllLeft.TabIndex = 2;
            this.BTN_AllLeft.Text = "<<";
            this.BTN_AllLeft.UseVisualStyleBackColor = true;
            this.BTN_AllLeft.Click += new System.EventHandler(this.BTN_AllLeft_Click);
            // 
            // BTN_SelectedRight
            // 
            this.BTN_SelectedRight.Location = new System.Drawing.Point(7, 70);
            this.BTN_SelectedRight.Name = "BTN_SelectedRight";
            this.BTN_SelectedRight.Size = new System.Drawing.Size(92, 23);
            this.BTN_SelectedRight.TabIndex = 1;
            this.BTN_SelectedRight.Text = ">";
            this.BTN_SelectedRight.UseVisualStyleBackColor = true;
            this.BTN_SelectedRight.Click += new System.EventHandler(this.BTN_SelectedRight_Click);
            // 
            // BTN_AllRight
            // 
            this.BTN_AllRight.Location = new System.Drawing.Point(6, 40);
            this.BTN_AllRight.Name = "BTN_AllRight";
            this.BTN_AllRight.Size = new System.Drawing.Size(93, 23);
            this.BTN_AllRight.TabIndex = 0;
            this.BTN_AllRight.Text = ">>";
            this.BTN_AllRight.UseVisualStyleBackColor = true;
            this.BTN_AllRight.Click += new System.EventHandler(this.BTN_AllRight_Click);
            // 
            // FRM_FieldSelections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FRM_FieldSelections";
            this.Text = "FRM_FieldSelections";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox LBX_AllFields;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox LBX_Selected;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN_SelectedLeft;
        private System.Windows.Forms.Button BTN_AllLeft;
        private System.Windows.Forms.Button BTN_SelectedRight;
        private System.Windows.Forms.Button BTN_AllRight;
    }
}