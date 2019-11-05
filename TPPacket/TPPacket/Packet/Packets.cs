using System;
using TPPacket.Class;

namespace TPPacket.Packet
{
    [Serializable]
    public class ConnectionPacket : BasePacket
    {
        public readonly bool IsConnecting;
        public readonly ulong ClientId;
        public readonly bool IsBot;
        public readonly bool HasError;

        private ConnectionPacket()
        {
            _packetType = PacketType.ConnectionStat;
        }

        public ConnectionPacket(bool _IsConnecting,  ulong _ClientId, bool _IsBot) : this()
        {
            IsConnecting = _IsConnecting;
            ClientId = _ClientId;
            IsBot = _IsBot;
            HasError = false;
        }

        public ConnectionPacket(bool _IsConnecting, ulong _ClientId, bool _IsBot, bool _HasError) : this()
        {
            IsConnecting = _IsConnecting;
            ClientId = _ClientId;
            IsBot = _IsBot;
            HasError = _HasError;
        }
    }

    [Serializable]
    public class CamPacket : BasePacket
    {
        public readonly byte[] CamFrame;

        private CamPacket()
        {
            _packetType = PacketType.CamFrame;
        }

        public CamPacket(byte[] _CamFrame) : this()
        {
            CamFrame = _CamFrame;
        }
    }

    [Serializable]
    public class CamResolutionReqPacket : BasePacket
    {
        public readonly int Resolution;

        private CamResolutionReqPacket()
        {
            _packetType = PacketType.CamResolutionReq;
        }

        public CamResolutionReqPacket(int resolution) : this()
        {
            Resolution = resolution;
        }
    }

    [Serializable]
    public class CamResolutionPacket : BasePacket
    {
        public readonly int Resolution;

        private CamResolutionPacket()
        {
            _packetType = PacketType.CamResolution;
        }

        public CamResolutionPacket(int resolution) : this()
        {
            Resolution = resolution;
        }
    }

    [Serializable]
    public class CamConfigPacket : BasePacket
    {
        public readonly CamaraConfigType camaraConfigType;
        public readonly bool enable;

        private CamConfigPacket()
        {
            _packetType = PacketType.CamConfig;
        }

        public CamConfigPacket(CamaraConfigType _camaraConfigType, bool _enable) : this()
        {
            camaraConfigType = _camaraConfigType;
            enable = _enable;
        }
    }

    [Serializable]
    public class CamPacketRecived : BasePacket
    {
        public CamPacketRecived()
        {
            _packetType = PacketType.CamReceived;
        }
    }

    [Serializable]
    public class CarStatusPacket : BasePacket
    {
        public readonly Cardevice cardevice;
        public readonly GPSPosition position;
        public readonly float rotation;

        private CarStatusPacket()
        {
            _packetType = PacketType.CarStatus;
        }

        public CarStatusPacket(Cardevice _cardevice, GPSPosition _position, float _rotation) : this()
        {
            cardevice = _cardevice;
            position = _position;
            rotation = _rotation;
        }
    }

    [Serializable]
    public class CarStatusRecivedPacket : BasePacket
    {
        public CarStatusRecivedPacket()
        {
            _packetType = PacketType.CarStatusReceived;
        }
    }

    [Serializable]
    public class CarGPSSpotStatusPacket : BasePacket
    {
        public readonly GPSSpotManagerChangeType GPSSpotManagerChangeType;
        public readonly int Index;
        public readonly GPSSpotManager GPSMover;
        public readonly GPSPosition GPSPosition;

        private CarGPSSpotStatusPacket()
        {
            _packetType = PacketType.CarGPSSpotStatus;
        }

        public CarGPSSpotStatusPacket(GPSSpotManagerChangeType gPSSpotManagerChangeType, object value) : this()
        {
            GPSSpotManagerChangeType = gPSSpotManagerChangeType;

            switch (gPSSpotManagerChangeType)
            {
                case GPSSpotManagerChangeType.AddSpot:
                    GPSPosition = value as GPSPosition;
                    break;
                case GPSSpotManagerChangeType.RemoveSpot:
                    Index = (int)value;
                    break;
                case GPSSpotManagerChangeType.SetCurrentPos:
                    Index = (int)value;
                    break;
                case GPSSpotManagerChangeType.OverWrite:
                    GPSMover = value as GPSSpotManager;
                    break;
                default:
                    break;
            }
        }
    }

    [Serializable]
    public class CarStatusChangeReqPacket : BasePacket
    {
        public readonly ReqCarDevice ReqCarDevice;

        private CarStatusChangeReqPacket()
        {
            _packetType = PacketType.CarStatusChangeReq;
        }

        public CarStatusChangeReqPacket(ReqCarDevice reqCarDevice) : this()
        {
            ReqCarDevice = reqCarDevice;
        }
    }

    [Serializable]
    public class CarGPSSpotStatusChangeReqPacket : BasePacket
    {
        public readonly GPSSpotManagerChangeType GPSSpotManagerChangeType;
        public readonly int Index;
        public readonly GPSSpotManager GPSMover;
        public readonly GPSPosition GPSPosition;

        private CarGPSSpotStatusChangeReqPacket()
        {
            _packetType = PacketType.CarGPSSpotStatusChangeReq;
        }

        public CarGPSSpotStatusChangeReqPacket(GPSSpotManagerChangeType gPSSpotManagerChangeType, object value) : this()
        {
            GPSSpotManagerChangeType = gPSSpotManagerChangeType;

            switch (gPSSpotManagerChangeType)
            {
                case GPSSpotManagerChangeType.AddSpot:
                    GPSPosition = value as GPSPosition;
                    break;
                case GPSSpotManagerChangeType.RemoveSpot:
                    Index = (int)value;
                    break;
                case GPSSpotManagerChangeType.SetCurrentPos:
                    Index = (int)value;
                    break;
                case GPSSpotManagerChangeType.OverWrite:
                    GPSMover = value as GPSSpotManager;
                    break;
                default:
                    break;
            }
        }
    }

    [Serializable]
    public class DataUpdatePacket : BasePacket
    {
        public readonly ModeType modeType;

        private DataUpdatePacket()
        {
            _packetType = PacketType.UpdateDataReq;
        }

        public DataUpdatePacket(ModeType _modeType) : this()
        {
            modeType = _modeType;
        }
    }

    [Serializable]
    public class DataUpdatedPacket : BasePacket
    {
        public readonly ModeType modeType;

        private DataUpdatedPacket()
        {
            _packetType = PacketType.UpdateDataChanged;
        }

        public DataUpdatedPacket(ModeType _modeType) : this()
        {
            modeType = _modeType;
        }
    }

    [Serializable]
    public class ConsoleUpdatePacket : BasePacket
    {
        public readonly ConsoleMode consoleMode;
        public readonly ulong TargetBot = 0;

        private ConsoleUpdatePacket()
        {
            _packetType = PacketType.UpdateConsoleModeReq;
        }

        public ConsoleUpdatePacket(ConsoleMode _consoleMode, ulong _TargetBot) : this()
        {
            consoleMode = _consoleMode;
            TargetBot = _TargetBot;
        }
    }

    [Serializable]
    public class ConsoleUpdatedPacket : BasePacket
    {
        public readonly ConsoleMode consoleMode;

        private ConsoleUpdatedPacket()
        {
            _packetType = PacketType.UpdateConsoleModeChanged;
        }

        public ConsoleUpdatedPacket(ConsoleMode _consoleMode) : this()
        {
            consoleMode = _consoleMode;
        }
    }

    [Serializable]
    public class UniversalCommandPacket : BasePacket
    {
        public readonly KeyType keyType;
        public readonly string key;

        private UniversalCommandPacket()
        {
            _packetType = PacketType.UniversalCommand;
        }

        public UniversalCommandPacket(KeyType _keyType, string _key) : this()
        {
            keyType = _keyType;
            key = _key;
        }
    }

    [Serializable]
    public class ClientinfoReqPacket : BasePacket
    {
        public ClientinfoReqPacket()
        {
            _packetType = PacketType.ClientsInfoReq;
        }
    }

    [Serializable]
    public class ClientinfoPacket : BasePacket
    {
        public readonly ClientInfo[] ClientsInfo;
        
        private ClientinfoPacket()
        {
            _packetType = PacketType.ClientsInfo;
        }

        public ClientinfoPacket(ClientInfo[] clientsInfo) : this()
        {
            ClientsInfo = clientsInfo;
        }
    }
}