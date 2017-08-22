// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using Newtonsoft.Json.Linq;

    class Type
    {
        public ushort ID;
        public JObject Json;
        public Reader Reader;

        public Type(Reader reader, ushort id)
        {
            this.Reader = reader;
            this.ID = id;

            this.Json = new JObject();
        }

        public virtual void Decode()
        {
        }
    }
}