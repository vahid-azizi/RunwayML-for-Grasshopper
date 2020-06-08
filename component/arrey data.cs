﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Runway.component
{
    public class arrey_data : GH_Component
    {
        
        public arrey_data()
          : base("Array to json ", "aj",
              "convert array data to json",
              "Runway", "Text")
        {
        }

       
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Array name", "nc>", "", GH_ParamAccess.item);
            pManager.AddTextParameter("Data", "dc>", "", GH_ParamAccess.list);
        }
       
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Data>", "D>", "", GH_ParamAccess.item);
        }

       
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "";
            List<string> data = new List<string>();
            string jason = "";
            
            DA.GetData(0, ref name);
            DA.GetDataList(1,  data);
            ////convert array to json
            for (int i = 0; i < data.Count; i++)
            {
                if (i == 0)
                {
                    jason += "[";
                    jason += data[i];
                }
                else if (i < data.Count - 1)
                {
                    jason += ",";
                    jason += data[i];
                }
                else jason += "]";
            }
            string Name = "\"" + name + "\":";
            string Data = jason;
            string json = Name + Data;
            DA.SetData(0, json);

        }

     
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
           
                return Properties.Resources.ber;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("05608f3a-16c2-4855-a68f-0aa3f83dc865"); }
        }
    }
}