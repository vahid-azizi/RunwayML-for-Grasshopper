﻿using System;
using System.Drawing;
using Grasshopper.Kernel;


namespace Runway
{
    public class RunwayInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Runway";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return Properties.Resources.runway ;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "RunwayML Machine learning for creators Bring the power of artificial " +
                       "intelligence to your creative projects with an intuitive and simple visual interface." +
                       " Start exploring new ways of creating today.";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("fe734ebf-3916-47d6-936b-469eb954c031");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Vahid Azizi";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "vahid.azizi.1992@gmail.com & Runwayml.com & for this plugin:parsiocad.com";
            }
        }
    }
}
