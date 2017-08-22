// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System.IO;

    static class VInt
    {
        public static int ReadVInt(this BinaryReader br)
        {
            int v5;
            byte b = br.ReadByte();
            v5 = b & 0x80;
            int _LR = b & 0x3F;

            if ((b & 0x40) != 0)
            {
                if (v5 != 0)
                {
                    b = br.ReadByte();
                    v5 = ((b << 6) & 0x1FC0) | _LR;
                    if ((b & 0x80) != 0)
                    {
                        b = br.ReadByte();
                        v5 = v5 | ((b << 13) & 0xFE000);
                        if ((b & 0x80) != 0)
                        {
                            b = br.ReadByte();
                            v5 = v5 | ((b << 20) & 0x7F00000);
                            if ((b & 0x80) != 0)
                            {
                                b = br.ReadByte();
                                _LR = (int)(v5 | (b << 27) | 0x80000000);
                            }
                            else
                            {
                                _LR = (int)(v5 | 0xF8000000);
                            }
                        }
                        else
                        {
                            _LR = (int)(v5 | 0xFFF00000);
                        }
                    }
                    else
                    {
                        _LR = (int)(v5 | 0xFFFFE000);
                    }
                }
            }
            else
            {
                if (v5 != 0)
                {
                    b = br.ReadByte();
                    _LR |= (b << 6) & 0x1FC0;
                    if ((b & 0x80) != 0)
                    {
                        b = br.ReadByte();
                        _LR |= (b << 13) & 0xFE000;
                        if ((b & 0x80) != 0)
                        {
                            b = br.ReadByte();
                            _LR |= (b << 20) & 0x7F00000;
                            if ((b & 0x80) != 0)
                            {
                                b = br.ReadByte();
                                _LR |= b << 27;
                            }
                        }
                    }
                }
            }

            return _LR;
        }
    }
}