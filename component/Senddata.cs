using System;
using System.IO;
using System.Net;
using Grasshopper.Kernel;
using Runway.component;


namespace Runway
{
    public class SendData : GH_Component
    {
        public SendData()
          : base("Data to runway", "sd",
              "convert data to json and send to runway",
              "Runway", "Data")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("http address", "HA", "http address model from runway", GH_ParamAccess.item);
            pManager.AddTextParameter("<<<Data ", "D", "data send to runway", GH_ParamAccess.item, "");
            pManager.AddIntegerParameter("Timeout", "t", "set time out for set delay GetRequestStream", GH_ParamAccess.item, 50000);
            pManager.AddBooleanParameter("Run", "R", "Run", GH_ParamAccess.item, false);
            

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Data>>", "D>>", "Data from Runway", GH_ParamAccess.item);

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            string address = null;
       
            Boolean run = false;
            string test = "";

            int delay =0;
            
            DA.GetData(0, ref address);
            DA.GetData(1, ref test);
            DA.GetData(2, ref delay);
            DA.GetData(3, ref run);
           
           
            
            string addressfinal = address + "/query";
            if (run)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(addressfinal);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = delay;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = test;
                    streamWriter.Write(json);
                    DA.SetData(0, json);

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                }
            }

        }

     
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
              
                return Properties.Resources.Group_23;
            }
        }

        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);
        public override Guid ComponentGuid
        {
            get { return new Guid("87d7628d-9063-4c5b-9ace-abf2763ade10"); }
        }
    }
}