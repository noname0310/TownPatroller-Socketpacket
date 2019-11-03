using System;

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
