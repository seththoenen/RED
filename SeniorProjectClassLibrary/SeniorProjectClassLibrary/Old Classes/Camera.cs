using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Camera : Equipment
    {
        private string megapixels;
        private string zoomInfo;
    
        public string MegaPixels
        {
            get
            {
                return megapixels;
            }
            set
            {
                megapixels = value;
            }
        }

        public string ZoomInfo
        {
            get
            {
                return zoomInfo;
            }
            set
            {
                zoomInfo = value;
            }
        }
    }
}
