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
    public partial class FRM_XCELType : Form
    {

        public string XCELType = "CCTV";

        public FRM_XCELType()
        {
            InitializeComponent();
        }

        private void FRM_XCELType_Load(object sender, EventArgs e)
        {
            LBX_Types.Items.Add("CCTV");                // Convert CBS CCTV spreadsheet into IPAM Import File
            LBX_Types.Items.Add("Access Control");      // Convert CBS Access Control spreadsheet into IPAM Import File
            LBX_Types.Items.Add("Workstations");        // Convert CBS Workstation spreadsheet into IPAM Import File
            LBX_Types.Items.Add("IPAM Import");         // No Conversion

            TBX_Type.Text = "CCTV";
            XCELType = "CCTV";
        }

        private void LBX_Types_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Idx = (sender as ListBox).SelectedIndex;
            TBX_Type.Text = (sender as ListBox).Items[Idx].ToString();
            XCELType = TBX_Type.Text;
        }

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

    }
}
