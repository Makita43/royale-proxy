// *******************************************************
// Created at 22/08/2017
// *******************************************************

using System;

namespace Royale_Proxy
{
    static class Utils
    {
        public static void Increment(this byte[] nonce, int timesToIncrease = 2)
        {
            for (int j = 0; j < timesToIncrease; j++)
            {
                ushort c = 1;
                for (UInt32 i = 0; i < nonce.Length; i++)
                {
                    c += nonce[i];
                    nonce[i] = (byte)c;
                    c >>= 8;
                }
            }
        }
    }
}