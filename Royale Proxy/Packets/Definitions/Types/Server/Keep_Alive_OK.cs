// *******************************************************
// Created at 27/08/2017 - Last Edit at 27/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Server
{
    class Keep_Alive_OK : Type
    {
        public Keep_Alive_OK(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
        }
    }
}