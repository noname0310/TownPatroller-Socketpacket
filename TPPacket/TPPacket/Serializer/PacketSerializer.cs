using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TPPacket.Packet;

namespace TPPacket.Serializer
{
    public class PacketSerializer
    {
        private int PacketBufferSize;//1024 * 3
        private int SegmentBufferSize;//1024 * 4
        private MemoryStream SerializeMS;
        private int SegmentCount;
        private int CourrentCount;
        private int CourrentSegmentID;

        public PacketSerializer(int _PacketBufferSize, int _SegmentBufferSize)
        {
            PacketBufferSize = _PacketBufferSize;
            SegmentBufferSize = _SegmentBufferSize;
            SegmentCount = -1;
            CourrentCount = 0;
            CourrentSegmentID = 0;
        }

        public void Serialize(object obj)
        {
            SerializeMS = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(SerializeMS, obj);
            SerializeMS.Position = 0;//

            SegmentCount = (int)Math.Ceiling(SerializeMS.Length/PacketBufferSize + 0D);
            CourrentCount = 0;
            CourrentSegmentID++;
        }

        private void SerializeSingle(byte[] buffer, object obj)//buffer = out
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, obj);
            ms.Position = 0;

            if(ms.Read(buffer, 0, buffer.Length) != 0)
            {
                throw new SystemException("buffer is too small to serialize object!");
            }
            ms.Close();
            ms.Dispose();
        }

        public int GetSerializedSegment(byte[] buffer)//buffer = out, 1024 * 3
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
