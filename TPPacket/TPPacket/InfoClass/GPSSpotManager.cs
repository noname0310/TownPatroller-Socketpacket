using System;
using System.Collections.Generic;

namespace TPPacket.Class
{
    [Serializable]
    public class GPSSpotManager
    {
        public List<GPSPosition> GPSPositions { get; private set; }
        public int CurrentMovePosIndex { get; set; }

        public GPSSpotManager(int _CurrentMovePosIndex)
        {
            GPSPositions = new List<GPSPosition>();
            CurrentMovePosIndex = _CurrentMovePosIndex;
        }

        private GPSSpotManager(List<GPSPosition> gPSPositions, int _CurrentMovePosIndex)
        {
            GPSPositions = gPSPositions;
            CurrentMovePosIndex = _CurrentMovePosIndex;
        }

        public GPSSpotManager Clone()
        {
            return new GPSSpotManager(GPSPositions, CurrentMovePosIndex);
        }

        public void MoveNext()
        {
            if (CurrentMovePosIndex == GPSPositions.Count - 1)
            {
                CurrentMovePosIndex = 0;
            }
            else
            {
                CurrentMovePosIndex++;
            }
        }

        public void AddPos(GPSPosition gPSPosition)
        {
            GPSPositions.Add(gPSPosition);
        }

        public void AddPos(string LocationName, float latitude, float longitude)
        {
            GPSPositions.Add(new GPSPosition(LocationName, latitude, longitude));
        }

        public void RemovePos(int index)
        {
            GPSPositions.RemoveAt(index);
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
