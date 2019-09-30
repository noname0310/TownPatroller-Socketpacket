using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPPacket.Packet;

namespace TPPacket.PacketManager
{
    public class PacketReciver
    {
        public delegate void DataInvoked(BasePacket basePacket);
        public event DataInvoked OnDataInvoke;

        private Dictionary<int, SegmentCollecter> segmentCollecters;

        public PacketReciver()
        {
            segmentCollecters = new Dictionary<int, SegmentCollecter>();
        }

        public void AddSegment(Segment segment)
        {
            if(segmentCollecters.ContainsKey(segment.SegmentID))
            {
                segmentCollecters[segment.SegmentID].AddSegment(segment);
            }
            else
            {
                segmentCollecters.Add(segment.SegmentID, new SegmentCollecter(segment));
                segmentCollecters[segment.SegmentID].OnDataInvoke += PacketReciver_OnDataInvoke;
            }
        }

        private void PacketReciver_OnDataInvoke(BasePacket basePacket, int segmentID)
        {
            OnDataInvoke?.Invoke(basePacket);
            segmentCollecters.Remove(segmentID);
        }
    }
}
