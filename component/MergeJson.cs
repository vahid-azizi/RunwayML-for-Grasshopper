using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Runway.component
{
    public class MergeJson : GH_Component
    {
       
        public MergeJson()
          : base("Json", "j",
              "this component convert merged data ",
              "Runway", "Text")
        {
        }

       
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("<Data", "<D", "this component convert merged data", GH_ParamAccess.item);

        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Data>>>", "d>>>", "", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "";
            string data = "";
            DA.GetData(0, ref name);
           ////convert all data to json
           string json ="{"+name+"}" ;
            
            DA.SetData(0, json);
        }

  
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                
                return Properties.Resources.json;
            }
        }
        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);
        public override Guid ComponentGuid
        {
            get { return new Guid("f0f84805-92fc-4f45-893c-6abf79e2b7a9"); }
        }
    }
}