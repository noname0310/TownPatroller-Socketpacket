using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPPacket.Packet;
using TPPacket.Serializer;

namespace TPPacket.PacketManager
{
    class SegmentCollecter
    {
        public delegate void DataInvoked(BasePacket basePacket, int segmentID);
        public event DataInvoked OnDataInvoke;

        private Segment[] segments;
        private int AddCount;

        private SegmentCollecter()
        {

        }

        public SegmentCollecter(Segment _segment)
        {
            AddCount = 0;
            segments = new Segment[_segment.SegmentCount];

            AddSegment(_segment);
        }

        public void AddSegment(Segment _segment)
        {
            segments[_segment.CourrentCount - 1] = _segment;
            AddCount++;

            if(AddCount == segments.Length)
            {
                BasePacket basePacket = PacketDeserializer.DeserializeFromSegment(segments);
                OnDataInvoke?.Invoke(basePacket, _segment.SegmentID);
            }
        }
    }
}
