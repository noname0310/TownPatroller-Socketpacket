using System.Collections.Generic;
using TPPacket.Packet;
using TPPacket.Serializer;

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

        public void AddSegment(byte[] segment)
        {
            HeaderInfo headerInfo = PacketDeserializer.ParseHeader(segment);

            if (headerInfo.CourrentSegmentID >= 1000)
            {
                if (segmentCollecters.Count > 0)
                    segmentCollecters.Clear();

                if(LastCollecter == null)
                {
                    LastCollecter = new SegmentCollecter(headerInfo.SegmentCount, headerInfo.CourrentSegmentID);
                    LastCollecter.OnDataInvoke += PacketReciver_OnDataInvoke;
                }
                LastCollecter.AddSegment(segment, PacketHeaderSize.HeaderSize);
                return;
            }

            if(headerInfo.CourrentSegmentID == 1)
            {
                LastCollecter = null;
            }

            if(segmentCollecters.ContainsKey(headerInfo.CourrentSegmentID))
            {
                segmentCollecters[headerInfo.CourrentSegmentID].AddSegment(segment, PacketHeaderSize.HeaderSize);
            }
            else
            {
                SegmentCollecter segmentCollecter = new SegmentCollecter(headerInfo.SegmentCount, headerInfo.CourrentSegmentID);
                segmentCollecter.OnDataInvoke += PacketReciver_OnDataInvoke;
                
                segmentCollecter.AddSegment(segment, PacketHeaderSize.HeaderSize);
                segmentCollecters.Add(headerInfo.CourrentSegmentID, segmentCollecter);
            }
        }

        private void PacketReciver_OnDataInvoke(BasePacket basePacket, int segmentID)
        {
            OnDataInvoke?.Invoke(Id, basePacket);
            segmentCollecters.Remove(segmentID);
        }
    }
}
