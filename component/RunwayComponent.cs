using System;
using Grasshopper.Kernel;
using Runway.component;


namespace Runway
{
    public class RunwayComponent : GH_Component
    {
      
        public RunwayComponent()
          : base(
              "Data from runway",
              "RS",
              "Please enter the http address.",
              "Runway",
              "Data")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Input http", "it", "example http://localhost:8000", GH_ParamAccess.item, "");
            pManager.AddBooleanParameter("Run", "R", "Run ", GH_ParamAccess.item, false);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Data>>", "D>>", "output runway live data", GH_ParamAccess.item);
            pManager.AddTextParameter("Info", "i", "output runway live data", GH_ParamAccess.item);
            pManager.AddTextParameter("Error", "e", "output runway live data", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            // define parameter

            string mainAddress= "";
           
            bool Brun = false;
            DA.GetData(0, ref mainAddress);
        
            DA.GetData(1, ref Brun);

            //

            using (System.Net.WebClient client = new System.Net.WebClient()) {
                string clientMain = client.DownloadString(mainAddress);

                if (Brun == true && clientMain != "") {
                    ExpireSolution(true);
                   
                        string data = client.DownloadString(mainAddress + "/data");
                        DA.SetData(0, data);
                        
                        string infodata = client.DownloadString(mainAddress + "/info");
                        DA.SetData(1, infodata);

                        string error = client.DownloadString(mainAddress + "/error");
                        DA.SetData(2, error);
                    

                }

            }

        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                
                return Properties.Resources.Group_25;
            }
        }
        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);
        public override Guid ComponentGuid
        {
            get { return new Guid("a9c05115-f56a-44d9-bd7b-03dc5832a01f"); }
        }
    }
}
