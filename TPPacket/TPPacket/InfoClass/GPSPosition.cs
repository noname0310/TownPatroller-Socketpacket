using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPPacket.Class
{
    [Serializable]
    public class GPSPosition
    {
        public readonly string LocationName;
        public readonly float latitude;
        public readonly float longitude;

        public GPSPosition(string locationName, float lati, float longi)
        {
            LocationName = locationName;
            latitude = lati;
            longitude = longi;
        }
    }
}
