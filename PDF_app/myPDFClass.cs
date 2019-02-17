using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDF_app
{
    class myPDFClass
    {
        public int AnnotID { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string NewComment { get; set; }
    }

    class myIPAMClass
    {
        public int ID { get; set; }
        public string IPAddress { get; set; }           //need
        public string Status { get; set; }              //always "Active"
        public string Description { get; set; }         //need
        public string Hostname { get; set; }            //{CCTV, Access Control,...}
        public string Mac { get; set; }
        public string TheSwitch { get; set; }
        public string Unknown { get; set; }
        public string Port { get; set; }                //DL# - port#
        public string Note { get; set; }                //Data Information?? R1-D2 etc
        public string SerialNumber { get; set; }
        public string DeviceLocation { get; set; }
    }
}
