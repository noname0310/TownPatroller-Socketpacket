using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TPPacket.Packet;

namespace TPPacket.Serializer
{
    public static class PacketHeaderSize
    {
        public const int HeaderSize = 4 * 3;//byte
    }

    public class PacketSerializer//header = 4byte * 3
    {
        private int PacketBufferSize;//1012       SegmentBufferSize = 1024
        public MemoryStream PacketMS;
        public int SegmentCount;
        public int CourrentSegmentID;

        public PacketSerializer(int _PacketBufferSize)
        {
            PacketBufferSize = _PacketBufferSize;
            SegmentCount = -1;
            CourrentSegmentID = 0;
        }

        ~PacketSerializer()
        {
            if (PacketMS != null)
            {
                PacketMS.Close();
                PacketMS.Dispose();
                PacketMS = null;
            }
        }

        public void Serialize(object obj)
        {
            if (PacketMS != null)
            {
                PacketMS.Close();
                PacketMS.Dispose();
                PacketMS = null;
            }
            
            PacketMS = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(PacketMS, obj);
            PacketMS.Position = 0;

            SegmentCount = (int)Math.Ceiling(PacketMS.Length/(double)PacketBufferSize);
            if (CourrentSegmentID == 1000)
                CourrentSegmentID = 1;
            else
                CourrentSegmentID++;
        }

        public void AddHeader(byte[] header, byte[] out_segment)//out_segment)//buffer = out
        {
            Buffer.BlockCopy(header, 0, out_segment, 0, header.Length);
        }

        public int GetSerializedSegment(byte[] out_segment)//out_segment = out, 1024
        {
            byte[] Header = new byte[4 * 3];

            byte[] CourrentSegmentIDByte = BitConverter.GetBytes(CourrentSegmentID);
            Buffer.BlockCopy(CourrentSegmentIDByte, 0, Header, 4, CourrentSegmentIDByte.Length);/*add CourrentSegmentID to header*/
            byte[] SegmentCountByte = BitConverter.GetBytes(SegmentCount);
            Buffer.BlockCopy(SegmentCountByte, 0, Header, 4 * 2, SegmentCountByte.Length);/*add SegmentCount to header*/

            int readbytes;

            if ((PacketMS.Length - PacketMS.Position) >= PacketBufferSize)
            {
                byte[] SegmentLengthByte = BitConverter.GetBytes(PacketBufferSize);
                Buffer.BlockCopy(SegmentLengthByte, 0, Header, 0, SegmentLengthByte.Length);/*add lengthinfo to header*/

                readbytes = PacketMS.Read(out_segment, Header.Length, PacketBufferSize);/*write segment at out_segment  offset 12byte*/
            }
            else
            {
                byte[] SegmentLengthByte = BitConverter.GetBytes((int)PacketMS.Length - (int)PacketMS.Position);
                Buffer.BlockCopy(SegmentLengthByte, 0, Header, 0, SegmentLengthByte.Length);/*add lengthinfo to header*/

                readbytes = PacketMS.Read(out_segment, Header.Length, (int)PacketMS.Length - (int)PacketMS.Position);/*write segment at out_segment  offset 12byte*/
            }

            AddHeader(Header, out_segment);

            return Header.Length + readbytes;/*return full segment length*/
        }

        public void Clear()
        {
            PacketMS.Close();
            PacketMS.Dispose();
            PacketMS = null;
        }
    }
}
