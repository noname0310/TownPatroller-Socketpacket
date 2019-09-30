using System;
using UnityEngine;
using TPPacket.Class;

namespace TPPacket.Packet
{
    [Serializable]
    public class ConnectionPacket : BasePacket
    {
        public readonly bool IsConnecting;

        private ConnectionPacket()
        {
            
        }

        public ConnectionPacket(bool _IsConnecting)
        {
            packetType = PacketType.ConnectionStat;
            IsConnecting = _IsConnecting;
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
            packetType = PacketType.CamFrame;
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
            packetType = PacketType.CarStatus;
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
            packetType = PacketType.CarStatusChanged;
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
            packetType = PacketType.UpdateDataReq;
            modeType = _modeType;
        }
    }

    [Serializable]
    public class DataUpdatedPacket : BasePacket
    {
        public DataUpdatedPacket()
        {
            packetType = PacketType.UpdateChanged;
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
            packetType = PacketType.UniversalCommand;
            keyType = _keyType;
            key = _key;
        }
    }
}
