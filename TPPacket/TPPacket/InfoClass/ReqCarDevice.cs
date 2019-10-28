using System;

namespace TPPacket.Class
{
    [Serializable]
    public class ReqCarDevice
    {
        public readonly bool R_motorpowerChanged = false;
        public readonly bool L_motorpowerChanged = false;
        public readonly bool R_motorDIRChanged = false;
        public readonly bool L_motorDIRChanged = false;

        public readonly bool RF_LEDChanged = false;
        public readonly bool LF_LEDChanged = false;
        public readonly bool RB_LEDChanged = false;
        public readonly bool LB_LEDChanged = false;

        //////////////////////////////////////////////////

        public readonly byte R_motorpower;
        public readonly byte L_motorpower;
        public readonly bool R_motorDIR;
        public readonly bool L_motorDIR;

        public readonly bool RF_LED;
        public readonly bool LF_LED;
        public readonly bool RB_LED;
        public readonly bool LB_LED;

        public ReqCarDevice(byte r_motorpower, byte l_motorpower, bool r_motorDIR, bool l_motorDIR)
        {
            R_motorpower = r_motorpower;
            L_motorpower = l_motorpower;
            R_motorDIR = r_motorDIR;
            L_motorDIR = l_motorDIR;

            R_motorpowerChanged = true;
            L_motorpowerChanged = true;
            R_motorDIRChanged = true;
            L_motorDIRChanged = true;
        }

        public ReqCarDevice(bool rf_LED, bool lf_LED, bool rb_LED, bool lb_LED)
        {
            RF_LED = rf_LED;
            LF_LED = lf_LED;
            RB_LED = rb_LED;
            LB_LED = lb_LED;

            RF_LEDChanged = true;
            LF_LEDChanged = true;
            RB_LEDChanged = true;
            LB_LEDChanged = true;
        }

        public ReqCarDevice(ledType ledType1, bool value1, ledType ledType2, bool value2)
        {
            switch (ledType1)
            {
                case ledType.RF:
                    RF_LED = value1;
                    RF_LEDChanged = true;
                    break;
                case ledType.LF:
                    LF_LED = value1;
                    LF_LEDChanged = true;
                    break;
                case ledType.RB:
                    RB_LED = value1;
                    RB_LEDChanged = true;
                    break;
                case ledType.LB:
                    LB_LED = value1;
                    LB_LEDChanged = true;
                    break;
                default:
                    break;
            }

            switch (ledType2)
            {
                case ledType.RF:
                    RF_LED = value2;
                    RF_LEDChanged = true;
                    break;
                case ledType.LF:
                    LF_LED = value2;
                    LF_LEDChanged = true;
                    break;
                case ledType.RB:
                    RB_LED = value2;
                    RB_LEDChanged = true;
                    break;
                case ledType.LB:
                    LB_LED = value2;
                    LB_LEDChanged = true;
                    break;
                default:
                    break;
            }
        }

        public ReqCarDevice(ledType ledType, bool value)
        {
            switch (ledType)
            {
                case ledType.RF:
                    RF_LED = value;
                    RF_LEDChanged = true;
                    break;
                case ledType.LF:
                    LF_LED = value;
                    LF_LEDChanged = true;
                    break;
                case ledType.RB:
                    RB_LED = value;
                    RB_LEDChanged = true;
                    break;
                case ledType.LB:
                    LB_LED = value;
                    LB_LEDChanged = true;
                    break;
                default:
                    break;
            }
        }
        
        public enum ledType
        {
            RF,
            LF,
            RB,
            LB
        }
    }
}
