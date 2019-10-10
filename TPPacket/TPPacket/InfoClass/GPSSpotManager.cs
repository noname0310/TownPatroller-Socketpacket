using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPPacket.Class
{
    [Serializable]
    public class GPSSpotManager
    {
        public List<GPSPosition> GPSPositions { get; private set; }
        public int CurrentMovePosIndex { get; private set; }

        public GPSSpotManager(int _CurrentMovePosIndex)
        {
            GPSPositions = new List<GPSPosition>();
            CurrentMovePosIndex = _CurrentMovePosIndex;
        }

        public void AddPos(GPSPosition gPSPosition)
        {
            GPSPositions.Add(gPSPosition);
        }

        public GPSPosition RemoveLastPos()
        {
            if (GPSPositions.Count == 0)
                return null;

            GPSPosition gPSPosition = GPSPositions[0];

            GPSPositions.RemoveAt(0);

            return gPSPosition;
        }

        public void SetMovePos(List<GPSPosition> _gPSPositions)
        {
            GPSPositions = _gPSPositions;
        }
    }
}
