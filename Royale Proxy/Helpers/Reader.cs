// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;
    using System.IO;
    using System.Text;

    public class Reader : BinaryReader
    {
        public Reader(byte[] _Buffer)
            : base(new MemoryStream(_Buffer))
        {
        }

        public byte[] ReadAllBytes => this.ReadBytes((int)(this.BaseStream.Length - this.BaseStream.Position));

        public override int Read(byte[] _Buffer, int _Offset, int _Count)
        {
            return this.BaseStream.Read(_Buffer, 0, _Count);
        }

        public byte[] ReadArray()
        {
            int _Length = this.ReadInt32();
            if (_Length == -1 || _Length < -1 || _Length > this.BaseStream.Length - this.BaseStream.Position)
            {
                return null;
            }

            return this.ReadBytesWithEndian(_Length, false);
        }

        public override bool ReadBoolean()
        {
            switch (this.ReadByte())
            {
                case 0:
                    return false;

                case 1:
                    return true;

                default:
                    throw new Exception("Error when reading a bool in packet.");
            }
        }

        public override byte ReadByte() => (byte)this.BaseStream.ReadByte();

        public byte[] ReadBytes()
        {
            int length = this.ReadInt32();

            if (length == -1)
            {
                return null;
            }

            return this.ReadBytes(length);
        }

        public override short ReadInt16()
        {
            return (short)this.ReadUInt16();
        }

        public int ReadInt24()
        {
            byte[] _Temp = this.ReadBytesWithEndian(3, false);
            return (_Temp[0] << 16) | (_Temp[1] << 8) | _Temp[2];
        }

        public override int ReadInt32() => BitConverter.ToInt32(this.ReadBytesWithEndian(4), 0);

        public override long ReadInt64() => BitConverter.ToInt64(this.ReadBytesWithEndian(8), 0);

        public override string ReadString()
        {
            int _Length = this.ReadInt32();

            if (_Length <= -1 || _Length > this.BaseStream.Length - this.BaseStream.Position)
            {
                return null;
            }

            return Encoding.UTF8.GetString(this.ReadBytesWithEndian(_Length, false));
        }

        public override ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(this.ReadBytesWithEndian(2), 0);
        }

        public uint ReadUInt24()
        {
            return (uint)this.ReadInt24();
        }

        public override uint ReadUInt32()
        {
            return BitConverter.ToUInt32(this.ReadBytesWithEndian(4), 0);
        }

        public override ulong ReadUInt64()
        {
            return BitConverter.ToUInt64(this.ReadBytesWithEndian(8), 0);
        }

        public long Seek(long _Offset, SeekOrigin _Origin)
        {
            return this.BaseStream.Seek(_Offset, _Origin);
        }

        byte[] ReadBytesWithEndian(int _Count, bool _Endian = true)
        {
            var _Buffer = new byte[_Count];
            this.BaseStream.Read(_Buffer, 0, _Count);

            if (BitConverter.IsLittleEndian && _Endian)
            {
                Array.Reverse(_Buffer);
            }

            return _Buffer;
        }
    }
}