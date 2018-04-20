using System;

namespace SecurityAccess
{
    public class SecurityKey 
    {
       public UInt32 UdsCallback_CalcKey(UInt32 Seed, byte access)
        {
            UInt32 wSubSeed;
            UInt32 wMiddle;
            UInt32 wLastBit;
            UInt32 wLeft31Bits;
            UInt32 EncryptConstant = 0x5f9ea12a;
            UInt32 Key;
            byte  i, DB1, DB2, DB3, counter;
            UInt16 middle;
            wSubSeed = Seed;
            if (access == 0x01)
            {
                EncryptConstant = 0x5f9ea12a;
            }
            else if (access == 0x03)
            {
                EncryptConstant = 0xdcdfe990;
            }
            else if (access == 0x05)
            {
                EncryptConstant = 0x5d9a91ca;
            }
            else if (access == 0x07)
            {
                EncryptConstant = 0xdada7a30;
            }
            else if (access == 0x09)
            {
                EncryptConstant = 0xc1f5bbd4;
            }
            wMiddle = (byte)(Seed & 0x000000ff);
            middle = (UInt16)(((EncryptConstant & 0x00001000) >> 11) | ((EncryptConstant & 0x00400000) >> 22));
            switch (middle)
            {
                case 0:
                    wMiddle = (byte)(Seed & 0x000000ff);
                    break;
                case 1:
                    wMiddle = (byte)((Seed & 0x0000ff00) >> 8);
                    break;
                case 2:
                    wMiddle = (byte)((Seed & 0x00ff0000) >> 16);
                    break;
                case 3:
                    wMiddle = (byte)((Seed & 0xff000000) >> 24);
                    break;
            }
            DB1 = (byte)((EncryptConstant & 0x000007F8) >> 3);
            DB2 = (byte)(((EncryptConstant & 0x7F800000) >> 23) ^ 0xA5);
            DB3 = (byte)(((EncryptConstant & 0x003FC000) >> 14) ^ 0x5A);
            counter = (byte)((((wMiddle ^ DB1) & DB2) + DB3));
            for (i = 0; i < counter; i++)
            {
                wMiddle = ((wSubSeed & 0x20000000) / 0x20000000) ^ ((wSubSeed & 0x01000000) / 0x01000000)
                            ^ ((wSubSeed & 0x2000) / 0x2000) ^ ((wSubSeed & 0x08) / 0x08);
                wLastBit = (wMiddle & 0x00000001);
                wSubSeed = (UInt32)(wSubSeed << 1);
                wLeft31Bits = (UInt32)(wSubSeed & 0xFFFFFFFE);
                wSubSeed = (UInt32)(wLeft31Bits | wLastBit);
            }
            if ((EncryptConstant & 0x00000002)!=0)
            {
                wLeft31Bits = ((wSubSeed & 0x00FF0000) >> 8) |
                                ((wSubSeed & 0xFF000000) >> 24) |
                                ((wSubSeed & 0x000000FF) << 16) | ((wSubSeed & 0x0000FF00) << 16);
            }
            else
                wLeft31Bits = wSubSeed;
            Key = wLeft31Bits ^ EncryptConstant;
            return (Key);
        }
    }
}
