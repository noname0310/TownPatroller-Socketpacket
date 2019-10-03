using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPPacket.Packet;

namespace TPPacket.PacketManager
{
    public class PacketReciver
    {
        public delegate void DataInvoked(ulong Id, BasePacket basePacket);
        public event DataInvoked OnDataInvoke;

        public readonly ulong Id;
        private Dictionary<int, SegmentCollecter> segmentCollecters;

        public PacketReciver(ulong _Id)
        {
            Id = _Id;
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
            OnDataInvoke?.Invoke(Id, basePacket);
            segmentCollecters.Remove(segmentID);
        }
    }
}
