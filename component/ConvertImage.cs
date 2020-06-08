using System;
using System.Drawing;
using Grasshopper.Kernel;


namespace Runway.component
{
    public class ConvertImage : GH_Component
    {
        public ConvertImage()
          : base("Convert Image", "cv",
              "convert image to base 64 ",
              "Runway", "Image")
        {
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("address pic", "ap", "local address", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("base64", "b", "connect to string data ", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string addressjpg = "";
            DA.GetData(0, ref addressjpg);
            

            Image image = Image.FromFile(addressjpg);
           

            ImageConverter converter = new ImageConverter();
            byte[] outputt = (byte[])converter.ConvertTo(image, typeof(byte[]));

            string imagebase64 = Convert.ToBase64String(outputt);
            string finalImage = "data:image/jpeg;base64,"+ imagebase64;

            DA.SetData(0, finalImage);

        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources._64;
            }
        }
        public override void CreateAttributes() =>
            m_attributes = new Runway_Interface(this);
        public override Guid ComponentGuid
        {
            get { return new Guid("ac52991a-f847-4067-80e5-c6f55b31c967"); }
        }
    }
}