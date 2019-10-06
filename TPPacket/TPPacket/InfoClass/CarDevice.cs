using System;

namespace TPPacket.Class
{
    [Serializable]
    public class Cardevice
    {
        public readonly ushort F_sonardist;
        public readonly ushort RH_sonardist;
        public readonly ushort LH_sonardist;
        public readonly ushort RS_sonardist;
        public readonly ushort LS_sonardist;

        public readonly byte R_motorpower;
        public readonly byte L_motorpower;

        public readonly bool R_motorDIR;
        public readonly bool L_motorDIR;
        public readonly bool RF_LED;
        public readonly bool LF_LED;
        public readonly bool RB_LED;
        public readonly bool LB_LED;

        public Cardevice(ushort _F_sonardist, ushort _RH_sonardist, ushort _LH_sonardist, ushort _RS_sonardist, ushort _LS_sonardist, 
            byte _R_motorpower, byte _L_motorpower, 
            bool _R_motorDIR, bool _L_motorDIR, bool _RF_LED, bool _LF_LED, bool _RB_LED, bool _LB_LED)
        {
            F_sonardist = _F_sonardist;
            RH_sonardist = _RH_sonardist;
            LH_sonardist = _LH_sonardist;
            RS_sonardist = _RS_sonardist;
            LS_sonardist = _LS_sonardist;
            R_motorpower = _R_motorpower;
            L_motorpower = _L_motorpower;
            R_motorDIR = _R_motorDIR;
            L_motorDIR = _L_motorDIR;
            RF_LED = _RF_LED;
            LF_LED = _LF_LED;
            RB_LED = _RB_LED;
            LB_LED = _LB_LED;
        }
    }
}