using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TPPacket.Packet;

namespace TPPacket.Serializer
{
    public class PacketSerializer
    {
        private int PacketBufferSize;//1024 * 3
        private int SegmentBufferSize;//1024 * 4
        public MemoryStream SerializeMS;
        public int SegmentCount;
        private int CourrentCount;
        public int CourrentSegmentID;

        public PacketSerializer(int _PacketBufferSize, int _SegmentBufferSize)
        {
            PacketBufferSize = _PacketBufferSize;
            SegmentBufferSize = _SegmentBufferSize;
            SegmentCount = -1;
            CourrentCount = 0;
            CourrentSegmentID = 0;
        }

        ~PacketSerializer()
        {
            SerializeMS.Close();
            SerializeMS.Dispose();
            SerializeMS = null;
        }

        public void Serialize(object obj)
        {
            if (SerializeMS != null)
            {
                SerializeMS.Close();
                SerializeMS.Dispose();
                SerializeMS = null;
            }
            
            SerializeMS = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(SerializeMS, obj);
            SerializeMS.Position = 0;

            SegmentCount = (int)Math.Ceiling((double)SerializeMS.Length/(double)PacketBufferSize);
            CourrentCount = 0;
            if (CourrentSegmentID == 1000)
                CourrentSegmentID = 1;
            else
                CourrentSegmentID++;
        }

        public long SerializeSingle(byte[] buffer, object obj)//buffer = out
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, obj);
            ms.Position = 0;

            if (ms.Length > buffer.Length)
            {
                throw new SystemException("buffer is too small to serialize object! memorystream (" + ms.Length + " byte)" + " buffer (" + buffer.Length + " byte)");
            }

            ms.Read(buffer, 0, buffer.Length);

            long size = ms.Length;

            ms.Close();
            ms.Dispose();

            return size;
        }

        public int GetSerializedSegment(byte[] buffer)//buffer = out, 1024 * 4
        {
            CourrentCount++;

            byte[] PacketBuffer = new byte[PacketBufferSize];
            int result = SerializeMS.Read(PacketBuffer, 0, PacketBuffer.Length);
            Segment segment = new Segment(CourrentSegmentID, SegmentCount, CourrentCount, PacketBuffer);
            SerializeSingle(buffer, segment);
            return result;
        }

        public void Clear()
        {
            SerializeMS.Close();
            SerializeMS.Dispose();
            SerializeMS = null;
        }
    }
}
