using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Floatpointconverter
{
    
    
    /// <summary>
    /// This class convert double value to binary value.
    /// </summary>
    public static class DoubleToBinaryStringFormat
    {
        /// <summary>
        ///This structure give long value from double by long value
        /// take access to memory area from double value.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct DoubleToLongUnion
        {
            [FieldOffset(0)]
            public double sourceDouble;

            [FieldOffset(0)]
            public readonly long destLong;
        }
        /// <summary>
        /// This method convert double to binary IEEE754 string  format
        /// </summary>
        /// <param name="sourceD">Is incomming argument</param>
        /// <returns>Resulting value</returns>
        public static string DoubleToIEEE754(this double sourceD)
        {
            DoubleToLongUnion unionDL = new DoubleToLongUnion { sourceDouble = sourceD };
            return LongToString(unionDL.destLong);
        }
        private static string LongToString(long sourceL)
        {
            string destStr = string.Empty;
            int szLong = sizeof(long) << 3; //multiply 8
            for (int i = 0; i < szLong; i++)
            {
                if ((sourceL & 1) == 1)
                {
                    destStr += '1';
                }
                else
                {
                    destStr += '0';
                }
                
                sourceL = sourceL >> 1;
            }            
            return ReverseString(destStr);
        }
        private static string ReverseString(string destStr)
        {
            StringBuilder sb = new StringBuilder(destStr.Length);
            for (int i = destStr.Length - 1; i >= 0; i--)
            {
                sb.Append(destStr[i]);
            }
            return sb.ToString();
        }       
    }
}