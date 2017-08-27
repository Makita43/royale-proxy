// *******************************************************
// Created at 27/08/2017 - Last Edit at 27/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Client
{
    using System;
    using Type = Royale_Proxy.Type;

    class End_Client_Turn : Type
    {
        public End_Client_Turn(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("tick", this.Reader.ReadVInt());
            this.Json.Add("checksum", this.Reader.ReadVInt());

            int Count = this.Reader.ReadVInt();

            if (Count > 0)
            {
                this.Json.Add("count", Count);

                int CommandBytes = (int)(this.Reader.BaseStream.Length - this.Reader.BaseStream.Position) / Count - 2 * Count;

                for (int _Index = 0; _Index < Count; _Index++)
                {
                    this.Json.Add("Command", this.Reader.ReadVInt());
                    this.Json.Add("data", BitConverter.ToString(this.Reader.ReadBytes(CommandBytes)).Replace("-", string.Empty));
                }
            }
        }
    }
}