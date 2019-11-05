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
        CamConfig,
        CamResolutionReq,
        CamResolution,
        CamReceived,
        CarStatus,
        CarStatusReceived,
        CarGPSSpotStatus,
        CarStatusChangeReq,
        CarGPSSpotStatusChangeReq,
        UpdateDataReq,
        UpdateDataChanged,
        UpdateConsoleModeReq,
        UpdateConsoleModeChanged,
        UniversalCommand,
        ClientsInfoReq,
        ClientsInfo
    }

    [Serializable]
    public enum CamaraConfigType
    {
        ChangeCamara,
        SendFrame
    }

    [Serializable]
    public enum GPSSpotManagerChangeType
    {
        AddSpot,
        RemoveSpot,
        SetCurrentPos,
        OverWrite
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
