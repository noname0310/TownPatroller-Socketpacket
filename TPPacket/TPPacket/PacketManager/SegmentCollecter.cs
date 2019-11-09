using System;
using System.IO;
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

        private MemoryStream segments;
        private int SegmentCount;
        private int AddCount;
        private int SegmentID;

        public SegmentCollecter(int segmentcount, int segmentid)
        {
            AddCount = 0;
            SegmentCount = segmentcount;
            SegmentID = segmentid;
            segments = new MemoryStream();
        }

        ~ SegmentCollecter()
        {
            if (segments != null)
            {
                segments.Close();
                segments.Dispose();
                segments = null;
            }
        }

        public void AddSegment(byte[] segment, int offset)
        {
            segments.Write(segment, offset, segment.Length - offset);
            AddCount++;

            if(AddCount == SegmentCount)
            {
                BasePacket basePacket = (BasePacket)PacketDeserializer.Deserialize(segments);
                OnDataInvoke?.Invoke(basePacket, SegmentID);
                segments.Close();
                segments.Dispose();
                segments = null;
            }
        }
    }
}
