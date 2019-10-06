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
        CamReceived,
        CarStatus,
        CarGPSSpotStatus,
        CarStatusChangeReq,
        CarGPSSpotStatusChangeReq,
        CarStatusChanged,
        UpdateDataReq,
        UpdateDataChanged,
        UpdateConsoleModeReq,
        UpdateConsoleModeChanged,
        UniversalCommand
    }

    [Serializable]
    public enum CamaraConfigType
    {
        ChangeCamara,
        SendFrame
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

    [Serializable]
    public enum CarMember
    {
        f_sonardist,
        rh_sonardist,
        lh_sonardist,
        rs_sonardist,
        ls_sonardist,
        r_motorpower,
        l_motorpower,
        r_motorDIR,
        l_motorDIR,
        rf_LED,
        lf_LED,
        rb_LED,
        lb_LED
    }
}
