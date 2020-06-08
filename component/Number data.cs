using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Runway.component
{
    public class NUmber_data : GH_Component
    {
        
        public NUmber_data()
          : base("number to jason", "nj",
              "convert number data to json",
              "Runway", "Text")
        {
        }

      
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Number name", "nc", "name of category in runway model you select ", GH_ParamAccess.item);
            pManager.AddTextParameter("Data ", "dc", "data of category in runway model you select", GH_ParamAccess.item);
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
            //convert number to json data
            string Name = "\"" + name + "\":";
            string json = Name + data;
            DA.SetData(0, json);
        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
             
                return Properties.Resources.num;
            }
        }

        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);
        public override Guid ComponentGuid
        {
            get { return new Guid("08738692-99d7-4f53-8065-102c4c2763de"); }
        }
    }
}