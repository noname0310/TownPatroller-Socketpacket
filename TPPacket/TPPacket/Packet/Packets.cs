using System;
using UnityEngine;
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
            
        }

        public ConnectionPacket(bool _IsConnecting,  ulong _ClientId, bool _IsBot)
        {
            _packetType = PacketType.ConnectionStat;
            IsConnecting = _IsConnecting;
            ClientId = _ClientId;
            IsBot = _IsBot;
            HasError = false;
        }

        public ConnectionPacket(bool _IsConnecting, ulong _ClientId, bool _IsBot, bool _HasError)
        {
            _packetType = PacketType.ConnectionStat;
            IsConnecting = _IsConnecting;
            ClientId = _ClientId;
            IsBot = _IsBot;
            HasError = _HasError;
        }
    }

    [Serializable]
    public class CamPacket : BasePacket
    {
        public readonly Texture CamFrame;

        private CamPacket()
        {
            
        }

        public CamPacket(Texture _CamFrame)
        {
            _packetType = PacketType.CamFrame;
            CamFrame = _CamFrame;
        }
    }

    [Serializable]
    public class CarStatusPacket : BasePacket
    {
        public readonly Cardevice cardevice;
        public readonly GPSPosition position;
        public readonly float rotation;
        public readonly GPSSpotManager gPSMover;

        private CarStatusPacket()
        {
            
        }

        public CarStatusPacket(Cardevice _cardevice, GPSPosition _position, float _rotation, GPSSpotManager _gPSMover)
        {
            _packetType = PacketType.CarStatus;
            cardevice = _cardevice;
            position = _position;
            rotation = _rotation;
            gPSMover = _gPSMover;
        }
    }

    [Serializable]
    public class CarStatusUpdatedPacket : BasePacket
    {
        public CarStatusUpdatedPacket()
        {
            _packetType = PacketType.CarStatusChanged;
        }
    }

    [Serializable]
    public class DataUpdatePacket : BasePacket
    {
        public readonly ModeType modeType;

        private DataUpdatePacket()
        {
            
        }

        public DataUpdatePacket(ModeType _modeType)
        {
            _packetType = PacketType.UpdateDataReq;
            modeType = _modeType;
        }
    }

    [Serializable]
    public class DataUpdatedPacket : BasePacket
    {
        public DataUpdatedPacket()
        {
            _packetType = PacketType.UpdateDataChanged;
        }
    }

    [Serializable]
    public class ConsoleUpdatePacket : BasePacket
    {
        public readonly ConsoleMode consoleMode;
        public readonly ulong TargetBot = 0;

        private ConsoleUpdatePacket()
        {

        }

        public ConsoleUpdatePacket(ConsoleMode _consoleMode, ulong _TargetBot)
        {
            _packetType = PacketType.UpdateConsoleModeReq;
            consoleMode = _consoleMode;
            TargetBot = _TargetBot;
        }
    }

    [Serializable]
    public class ConsoleUpdatedPacket : BasePacket
    {
        public ConsoleUpdatedPacket()
        {
            _packetType = PacketType.UpdateConsoleModeChanged;
        }
    }

    [Serializable]
    public class UniversalCommandPacket : BasePacket
    {
        public readonly KeyType keyType;
        public readonly string key;

        private UniversalCommandPacket()
        {

        }

        public UniversalCommandPacket(KeyType _keyType, string _key)
        {
            _packetType = PacketType.UniversalCommand;
            keyType = _keyType;
            key = _key;
        }
    }
}
