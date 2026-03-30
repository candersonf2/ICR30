using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICR30
{
    public static class Utils
    {
        public static uint FauxHexToUInt(byte[] bF)
        {
            // Takes Icom's weird byte format that uses decimal values and outputs the number.
            int bFlen = bF.Length;
            int curpos = 0;
            uint uResult = 0;

            while (curpos < bFlen)
            {
                uResult += Convert.ToUInt32(((bF[curpos] & 0xf0) >> 4) * Math.Pow(10, ((bFlen - 1) * 2) - ((2 * curpos) - 1)) +
                    ((bF[curpos] & 0x0f) * Math.Pow(10, ((bFlen - 1) * 2) - ((2 * curpos)))));
                curpos++;
            }
            return uResult;
        }
        public static byte[] UIntToFauxHex(uint uVal, uint uLen)
        {
            // Creates Icom's weird byte format that stores values in base 10 instead of 16.
            byte[] bResult = new byte[uLen];
            string sVal = uVal.ToString("D" + (uLen * 2));
            if ((sVal.Length % 2) != 0) sVal = "0" + sVal;
            int curspos = 0;
            int curbpos = 0;
            while (curspos < sVal.Length && curbpos < bResult.Length)
            {
                bResult[curbpos] = (byte)(((((int)Char.GetNumericValue(sVal[curspos])) & 0x0f) << 4) | ((int)Char.GetNumericValue(sVal[curspos + 1])) & 0x0f);
                curspos += 2;
                curbpos++;
            }
            return bResult;
        }
        public static byte[] PackFreq(uint uFreq)
        {
            // Unpacks the odd format they send Frequency in.
            string sFreq = String.Format("{0:0000000000}", uFreq);
            byte b1 = (byte)Char.GetNumericValue(sFreq[9]);
            byte b10 = (byte)Char.GetNumericValue(sFreq[8]);
            byte b100 = (byte)Char.GetNumericValue(sFreq[7]);
            byte b1k = (byte)Char.GetNumericValue(sFreq[6]);
            byte b10k = (byte)Char.GetNumericValue(sFreq[5]);
            byte b100k = (byte)Char.GetNumericValue(sFreq[4]);
            byte b1M = (byte)Char.GetNumericValue(sFreq[3]);
            byte b10M = (byte)Char.GetNumericValue(sFreq[2]);
            byte b100M = (byte)Char.GetNumericValue(sFreq[1]);
            byte b1G = (byte)Char.GetNumericValue(sFreq[0]);
            byte[] ret = new byte[5];
            ret[0] = (byte)((b1 & 0xf) | ((b10 & 0xf) << 4));
            ret[1] = (byte)((b100 & 0xf) | ((b1k & 0xf) << 4));
            ret[2] = (byte)((b10k & 0xf) | ((b100k & 0xf) << 4));
            ret[3] = (byte)((b1M & 0xf) | ((b10M & 0xf) << 4));
            ret[4] = (byte)((b100M & 0xf) | ((b1G & 0xf) << 4));
            return ret;
        }
        public static uint UnpackFreq(byte[] fbytes)
        {
            // Packs a uint Frequency value into their odd format.
            uint f100M = (uint)(fbytes[4] & 0x0f) * 100000000;
            uint f1G = (uint)((fbytes[4] >> 4) & 0x0f) * 1000000000;
            uint f1M = (uint)(fbytes[3] & 0x0f) * 1000000;
            uint f10M = (uint)((fbytes[3] >> 4) & 0x0f) * 10000000;
            uint f10k = (uint)(fbytes[2] & 0x0f) * 10000;
            uint f100k = (uint)((fbytes[2] >> 4) & 0x0f) * 100000;
            uint f100 = (uint)(fbytes[1] & 0x0f) * 100;
            uint f1k = (uint)((fbytes[1] >> 4) & 0x0f) * 1000;
            uint f1 = (uint)(fbytes[0] & 0x0f);
            uint f10 = (uint)((fbytes[0] >> 4) & 0x0f) * 10;

            return f1G + f100M + f10M + f1M + f100k + f10k + f1k + f100 + f10 + f1;

        }
        public static string PrintByteArray(byte[] bytes)
        {
            // General Byte Array to string function, mostly for debugging.
            string retString = "";
            if (bytes == null) return "";
            for (int i = 0; i < bytes.Length; i++)
                retString += String.Format("{0:X2} ", bytes[i]);
            retString += Environment.NewLine;
            return retString;
        }
        public static byte[] StringToByteArrayFastest(string hex)
        {
            // Used for debugging to send hex digits as binary data easily.
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static bool GetBitFromByteArray(byte[] bArray, int iByte, int iBit)
        {
            // Useful for some of the long bitwise messages that are sent.
            // Mainly in use by the Scaninformation packet processor.
            if (bArray.Length < iByte + 1) return false;

            return ((bArray[iByte] >> iBit) & 0x01) == 1;
        }
        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
        public static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            // Not very efficient, but we aren't using this to go to the moon. Yet...
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 0);
            newArray[bArray.Length] = newByte;
            return newArray;
        }

        public static byte[] AppendByteArrray(byte[] array1, byte[] array2)
        {
            // Sometimes you just can't help but need to smash two byte arrays together.
            byte[] resultArray = new byte[array1.Length + array2.Length];
            System.Buffer.BlockCopy(array1, 0, resultArray, 0, array1.Length);
            System.Buffer.BlockCopy(array2, 0, resultArray, array1.Length, array2.Length);
            return resultArray;
        }
    }
}
