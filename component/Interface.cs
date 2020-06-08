
using System.Drawing;

using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;

namespace Runway.component
{
    public class Runway_Interface : Grasshopper.Kernel.Attributes.GH_ComponentAttributes
    {
        public Runway_Interface(GH_Component owner)
            : base(owner)
        {  }


        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {

            if (channel != GH_CanvasChannel.Objects)
            {
                base.Render(canvas, graphics, channel);
                return;
            }
    
            
            GH_Skin.palette_hidden_standard = Hds.Normal;
            GH_Skin.palette_hidden_selected = Hds.Selected;
            GH_Skin.palette_warning_standard = Hds.Warning;
            GH_Skin.palette_warning_selected = Hds.Selected;
            GH_Skin.palette_error_standard = Hds.Error;
            GH_Skin.palette_error_selected = Hds.Selected; 

            base.Render(canvas, graphics, channel);


            GH_Skin.palette_hidden_standard = Hds.StyleStandard;
            GH_Skin.palette_hidden_selected = Hds.StyleStyleSelected;
            GH_Skin.palette_warning_standard = Hds.StyleWStandard;
            GH_Skin.palette_warning_selected = Hds.StyleWSelected;
            GH_Skin.palette_error_standard = Hds.StyleEStandard;
            GH_Skin.palette_error_selected = Hds.StyleESelected;
        }
        
        public struct Hds
    {
       
           //  *******************       Vahid, you can change this part as you wish
        
        
        public static readonly Color A = Color.FromArgb(5,122,255);
        public static readonly Color B = Color.Black;
        public static readonly Color C = Color.FromArgb(115,229,162);
        public static readonly Color D = Color.FromArgb(unchecked((int) 0xffff7c00));   


        public static readonly GH_PaletteStyle Normal = new GH_PaletteStyle(B, C, C);
        public static readonly GH_PaletteStyle Selected = new GH_PaletteStyle(A, C, C);
        public static readonly GH_PaletteStyle Warning = new GH_PaletteStyle(B, C, C);
        public static readonly GH_PaletteStyle Error = new GH_PaletteStyle(D, C, Color.NavajoWhite);



        //  *******************       Never change anything from here on 
                                                                         



            public static readonly GH_PaletteStyle StyleStandard = GH_Skin.palette_hidden_standard;
        public static readonly GH_PaletteStyle StyleStyleSelected = GH_Skin.palette_hidden_selected;
        public static readonly GH_PaletteStyle StyleWStandard = GH_Skin.palette_warning_standard;
        public static readonly GH_PaletteStyle StyleWSelected = GH_Skin.palette_warning_selected;
        public static readonly GH_PaletteStyle StyleEStandard = GH_Skin.palette_error_standard;
        public static readonly GH_PaletteStyle StyleESelected = GH_Skin.palette_error_selected;


    
    }
    }



  

}
