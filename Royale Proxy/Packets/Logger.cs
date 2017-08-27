// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System.IO;

    class Logger
    {
        public Logger()
        {
            if (!Directory.Exists("Packets"))
            {
                Directory.CreateDirectory("Packets");
            }
        }

        public static void Write(string value, string name, LogType type)
        {
            switch (type)
            {
                case LogType.PACKET:
                {
                    File.WriteAllText($"Packets/{name}.bin", value);

                    break;
                }
            }
        }
    }
}