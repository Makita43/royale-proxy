// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System.Collections.Generic;

    class Packet_Names
    {
        static readonly Dictionary<ushort, string> List = new Dictionary<ushort, string>
        {
            { 10100, "Session_Request" },
            { 10107, "Client_Capabilities" },
            { 10108, "Keep_Alive" },
            { 14102, "End_Client_Turn" },
            { 14113, "Visit_Home_Data" },
            { 14303, "Request_Joinable_Clans" },

            { 20100, "Session_Success" },
            { 20103, "Login_Failed" },
            { 20108, "Keep_Alive_OK" },
            { 24101, "Own_Home_Data" },
            { 24111, "Available_Server_Command" },
            { 24113, "Visited_Home_Data" },
            { 24304, "Joinable_Clans" }
        };

        public static string GetName(ushort ID)
        {
            if (List.ContainsKey(ID))
            {
                return List[ID];
            }
            else
            {
                return "Unknown";
            }
        }
    }
}