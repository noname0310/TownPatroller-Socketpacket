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
        private SegmentCollecter LastCollecter;

        public PacketReciver(ulong _Id)
        {
            Id = _Id;
            segmentCollecters = new Dictionary<int, SegmentCollecter>();
        }

        public void AddSegment(Segment segment)
        {
            if(segment.SegmentID >= 1000)
            {
                if (segmentCollecters.Count > 0)
                    segmentCollecters.Clear();

                if(LastCollecter == null)
                {
                    LastCollecter = new SegmentCollecter(segment.SegmentCount);
                    LastCollecter.OnDataInvoke += PacketReciver_OnDataInvoke;
                }
                LastCollecter.AddSegment(segment);
                return;
            }

            if(segment.SegmentID == 1)
            {
                LastCollecter = null;
            }

            if(segmentCollecters.ContainsKey(segment.SegmentID))
            {
                segmentCollecters[segment.SegmentID].AddSegment(segment);
            }
            else
            {
                SegmentCollecter segmentCollecter = new SegmentCollecter(segment.SegmentCount);
                segmentCollecter.OnDataInvoke += PacketReciver_OnDataInvoke;

                segmentCollecter.AddSegment(segment);
                segmentCollecters.Add(segment.SegmentID, segmentCollecter);
            }
        }

        private void PacketReciver_OnDataInvoke(BasePacket basePacket, int segmentID)
        {
            OnDataInvoke?.Invoke(Id, basePacket);
            segmentCollecters.Remove(segmentID);
        }
    }
}
