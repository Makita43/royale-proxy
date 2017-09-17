using System.Collections.Generic;

namespace Royale_Proxy
{
    internal class Packet_Names
    {
        private static readonly Dictionary<ushort, string> List = new Dictionary<ushort, string>
        {
            {10100, "Session_Request"},
            {10107, "Client_Capabilities"},
            {10108, "Keep_Alive"},
            {10113, "Set_Device_Token"},
            {10116, "Reset_Account"},
            {10117, "Report_Player"},
            {10118, "Switch_Account"},
            {10121, "Unlock_Account"},
            {10150, "Apple_Billing_Request"},
            {10151, "Goggle_Billing_Request"},
            {10159, "Kunlun_Billing_Request"},
            {10212, "Change_Name"},
            {10905, "Opened_Inbox"},
            {12211, "Unbind_Facebook_Account"},
            {12903, "Request_Sector_State"},
            {12904, "Sector_Command"},
            {12951, "Send_Battle_Event"},
            {14101, "Go_Home"},
            {14102, "End_Client_Turn"},
            {14104, "Start_Mission"},
            {14105, "Stopped_Home_Logic"},
            {14107, "Cancel_Matchmaking"},
            {14113, "Visit_Home"},
            {14120, "Accept_Challenge"},
            {14123, "Cancel_Challenge"},
            {14201, "Bind_Facebook_Account"},
            {14212, "Bind_Gamecenter_Account"},
            {14262, "Bind_Google_Account"},
            {14301, "Create_Clan"},
            {14302, "Request_Clan_Data"},
            {14303, "Request_Joinable_Clans"},
            {14304, "Request_Clan_Stream"},
            {14305, "Join_Clan"},
            {14308, "Leave_Clan"},

            {20100, "Session_Success"},
            {20103, "Login_Failed"},
            {20108, "Keep_Alive_OK"},
            {20161, "Shutdown_Started"},
            {20205, "Name_Change_Failed"},
            {20206, "Friend_Status_Changed"},
            {20225, "Battle_Result"},
            {21903, "Sector_State"},
            {22952, "Battle_Event"},
            {24101, "Own_Home_Data"},
            {24104, "Out_Of_Sync"},
            {24106, "Stop_Home_Logic"},
            {24111, "Available_Server_Command"},
            {24112, "UDP_Info"},
            {24113, "Visit_Home_Data"},
            {24304, "Joinable_Clans"},
            {24403, "Top_Global_Players"},
            {24404, "Top_Local_Players"},
            {24411, "Avatar_Stream"}
        };

        public static string GetName(ushort ID)
        {
            if (List.ContainsKey(ID))
                return List[ID];
            return "Unknown";
        }
    }
}