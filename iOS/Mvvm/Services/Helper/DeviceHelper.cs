using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace xapps.iOS
{
    //Create statice device helper to capture the current device. This will be used to detect screen orientation
    public static class DeviceHelper
    {
        public static UIDevice iOSDevice
        {
            get;
            set;
        }
    }
}
