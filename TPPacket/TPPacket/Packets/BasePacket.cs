using System;

namespace TPPacket.Packet
{
    [Serializable]
    public class BasePacket
    {
        protected Segment segmentInfo;
        protected PacketType packetType;

        public Segment Segmentinfo
        {
            get
            {
                return segmentInfo;
            }
            set
            {
                segmentInfo = value;
            }
        }

        public BasePacket()
        {

        }
    }

    [Serializable]
    public enum PacketType
    {
        ConnectionStat,
        CamFrame,
        CarStatus,
        CarStatusChanged,
        UpdateDataReq,
        UpdateChanged,
        UniversalCommand
    }

    [Serializable]
    public enum ModeType
    {
        AutoDriveMode,
        ManualDriveMode,
        HaifManualDriveMode
    }

    [Serializable]
    public enum KeyType
    {
        PressDown,
        PressUP,
        Pressing,
        ConsoleMsg,
        Command
    }
}
