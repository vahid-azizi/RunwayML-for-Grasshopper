using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Runway.component
{
    public class String_data : GH_Component
    {
    
        public String_data()
          : base("String to jason", "sj",
              "convert string data to json",
              "Runway", "Text")
        {
        }

      
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("String name", "nc", "", GH_ParamAccess.item);
            pManager.AddTextParameter("Data ", "dc", "", GH_ParamAccess.item);
        }

        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Data>", "D>", "", GH_ParamAccess.item);
        }


        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "";
            string data = "";

            DA.GetData(0, ref name);
            DA.GetData(1, ref data);
            
            ///convert data to json format
           string Name = "\"" + name + "\":";
           string Data = "\"" + data +"\"";
           string json = Name + Data;
           DA.SetData(0, json);

        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                
                return Properties.Resources.text;
            }
        }
        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);

        public override Guid ComponentGuid
        {
            get { return new Guid("06c6abf8-9c40-425b-92f8-c37fc0c6b0a1"); }
        }
    }
}