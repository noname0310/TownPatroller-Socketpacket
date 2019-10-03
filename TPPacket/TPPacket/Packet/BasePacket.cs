using System;

namespace TPPacket.Packet
{
    [Serializable]
    public class BasePacket
    {
        public PacketType packetType
        {
            get
            {
                return _packetType;
            }
        }

        protected PacketType _packetType;

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
        UpdateDataChanged,
        UpdateConsoleModeReq,
        UpdateConsoleModeChanged,
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

    [Serializable]
    public enum ConsoleMode
    {
        ViewBotList,
        ViewSingleBot
    }
}
