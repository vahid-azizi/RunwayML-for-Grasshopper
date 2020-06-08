using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using Grasshopper.Kernel;
using Runway.component;


namespace Runway
{
    public class DecomposeImage : GH_Component
    {
      
        public DecomposeImage()
          : base("Decompose Image", "di",
              "Convert data to image ",
              "Runway",
              "Image")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("<< Data", "<<D", "input runway Data from Runway component ", GH_ParamAccess.item);
            pManager.AddBooleanParameter( "Run ","R" ," Run convert base 64 to image  ", GH_ParamAccess.item,false);
            pManager.AddIntegerParameter("Width(optional)", "W", "resize image width", GH_ParamAccess.item,100);
            pManager.AddIntegerParameter("Height(optional)", "H", "resize image height ", GH_ParamAccess.item,100);

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("color", "c", "color", GH_ParamAccess.item);
            pManager.AddTextParameter("black & white", "bw", "black & white", GH_ParamAccess.item);
            pManager.AddTextParameter("Red", "R", "Red channel", GH_ParamAccess.item);
            pManager.AddTextParameter("Green", "G", "Green channel", GH_ParamAccess.item);
            pManager.AddTextParameter("Blue", "B", "Blue channel", GH_ParamAccess.item);
            pManager.AddTextParameter("Alpha", "A", "Alpha channel", GH_ParamAccess.item);
            

        }


        protected override void SolveInstance(IGH_DataAccess DA)
        {
           
            String setdata = "";
            Boolean Reset = false;
            int pixwidth = 0;
            int pixheight = 0;
            int resizewidth = 0;
            int resizeheight = 0;
            List<string> color = new List<string>();
            List<double> blakWhite = new List<double>();
            List<int> red = new List<int>();
            List<int> green = new List<int>();
            List<int> blue = new List<int>();
            List<int> alpha = new List<int>();
            DA.GetData(0, ref setdata);
            DA.GetData(1, ref Reset);
            DA.GetData(2, ref resizewidth);
            DA.GetData(3, ref resizeheight);
            // convert data

            if (Reset)
            {
                
                //filter json data to base 64 image 
                char[] delimiterChars = {'"', '{', '}', ','};
                string phrase = setdata;
                string[] outputData = phrase.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                string finaltext = outputData[3];
                //convert base 64 to image

                Byte[] bitmapData = Convert.FromBase64String(finaltext);
                System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
                Bitmap bitImage = new Bitmap((Bitmap) Image.FromStream(streamBitmap));

                // width and height image ref to out put

                Bitmap resizeimage = ResizeBitmap(bitImage, resizewidth, resizeheight);
                // decompose image to rgb 


                using (Bitmap bmp = new Bitmap(resizeimage))
                {
                    
                    for (int j =0; j<resizewidth ;j++)
                    {
                        for (int i= 0;i<resizewidth; i++)
                        {
                            Color clr = bmp.GetPixel(i, j);
                           
                            color.Add(clr.R+","+ clr.G+","+clr.B);
                            double redd = double.Parse(clr.R.ToString());
                            double bulee = double.Parse(clr.B.ToString());
                            double grenn = double.Parse(clr.G.ToString());
                            double sum = redd+bulee+grenn;
                            double remap =sum/700;
                            blakWhite.Add(remap);
                            red.Add(clr.R);
                            green.Add(clr.G);
                            blue.Add(clr.B);
                            alpha.Add(255);

                        }

                    }


                }
            }

            //set data to out put component
            DA.SetDataList(0, color);
            DA.SetDataList(1, blakWhite);
            DA.SetDataList(2, red);
            DA.SetDataList(3, green);
            DA.SetDataList(4, blue);
            DA.SetDataList(5, alpha);
          

        }
        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                
                return Properties.Resources.decompose;
            }
        }
        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);
        public override Guid ComponentGuid
        {
            get { return new Guid("3750da58-fee7-4a96-8791-04929e85648e"); }
        }
    }
}