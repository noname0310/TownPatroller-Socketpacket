using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TPPacket.Packet;

namespace TPPacket.Serializer
{
    public class PacketDeserializer
    {
        public static BasePacket DeserializeFromSegment(Segment[] segments)
        {
            MemoryStream BufferStream = new MemoryStream();

            for (int i = 0; i < segments.Length; i++)
            {
                byte[] buffer = segments[i].PacketBuffer;
                BufferStream.Write(buffer, 0, buffer.Length);
            }

            return (BasePacket)Deserialize(BufferStream);
        }

        private static object Deserialize(MemoryStream DeserializeMS)
        {
            DeserializeMS.Position = 0;

            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(DeserializeMS);
            DeserializeMS.Close();
            return obj;
        }
    }
}
