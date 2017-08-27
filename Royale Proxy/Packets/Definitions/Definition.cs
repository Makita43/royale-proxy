// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Royale_Proxy.Packets.Definitions.Types.Client;
    using Royale_Proxy.Packets.Definitions.Types.Server;

    class Definition : Dictionary<ushort, System.Type>
    {
        public Definition()
        {
            this.Add(10100, typeof(Session_Request));
            this.Add(10101, typeof(Login));
            this.Add(10107, typeof(Client_Capabilities));
            this.Add(10108, typeof(Keep_Alive));
            this.Add(14102, typeof(End_Client_Turn));
            this.Add(14113, typeof(Visit_Home));

            this.Add(20100, typeof(Session_Success));
            this.Add(20104, typeof(Login_OK));
            this.Add(20108, typeof(Keep_Alive_OK));
            this.Add(24112, typeof(UDP_Info));
            this.Add(24113, typeof(Visited_Home_Data));

            Console.WriteLine($"Loaded {this.Count} definitions.");
        }

        public string Decode(Reader reader, ushort ID)
        {
            if (this.ContainsKey(ID))
            {
                try
                {
                    Type _Type = Activator.CreateInstance(this[ID], reader, ID) as Type;

                    _Type.Decode();

                    return _Type.Json.Count == 0 ? string.Empty : JsonConvert.SerializeObject(_Type.Json, Formatting.Indented);
                }
                catch (Exception)
                {
                    return $"Failed to decode {ID}.";
                }
            }
            else
            {
                return $"Missing definition for Packet {ID} [{Packet_Names.GetName(ID)}]";
            }
        }
    }
}