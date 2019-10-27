using System;

namespace TPPacket.Class
{
    [Serializable]
    public class ClientInfo
    {
        public readonly ulong ClientID;
        public readonly GPSPosition GPSPosition;

        public ClientInfo(ulong clientID, GPSPosition gPSPosition)
        {
            ClientID = clientID;
            GPSPosition = gPSPosition;
        }
    }
}
