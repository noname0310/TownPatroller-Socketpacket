using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TPPacket.Packet;

namespace TPPacket.Serializer
{
    public class PacketDeserializer
    {
        public static object Deserialize(byte[] buffer, int offset)
        {
            MemoryStream BufferStream = new MemoryStream();
            BufferStream.Write(buffer, offset, buffer.Length - offset);
            BufferStream.Position = 0;

            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(BufferStream);
            BufferStream.Close();
            return obj;
        }

        public static object Deserialize(byte[] buffer, int offset, int length)
        {
            MemoryStream BufferStream = new MemoryStream();
            BufferStream.Write(buffer, offset, length);
            BufferStream.Position = 0;

            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(BufferStream);
            BufferStream.Close();
            return obj;
        }

        public static object Deserialize(MemoryStream DeserializeMS)
        {
            DeserializeMS.Position = 0;

            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(DeserializeMS);
            DeserializeMS.Close();
            return obj;
        }

        public static HeaderInfo ParseHeader(byte[] segment)
        {
            HeaderInfo headerInfo;
            headerInfo.SegmentLength = BitConverter.ToInt32(segment, 0);
            headerInfo.CourrentSegmentID = BitConverter.ToInt32(segment, 4);
            headerInfo.SegmentCount = BitConverter.ToInt32(segment, 4 * 2);

            return headerInfo;
        }
    }

    public struct HeaderInfo
    {
        public int SegmentLength;
        public int CourrentSegmentID;
        public int SegmentCount;
    }
}
