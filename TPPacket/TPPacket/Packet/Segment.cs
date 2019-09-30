using System;

namespace TPPacket.Packet
{
    [Serializable]
    public class Segment
    {
        public readonly int SegmentID;
        public readonly int SegmentCount;
        public readonly int CourrentCount;
        public byte[] PacketBuffer { get; private set; }

        private Segment()
        {

        }

        public Segment(int segmentID, int _SegmentCount, int _CourrentCount, byte[] _PacketBuffer)
        {
            SegmentID = segmentID;
            SegmentCount = _SegmentCount;
            CourrentCount = _CourrentCount;
            PacketBuffer = _PacketBuffer;
        }
    }
}
