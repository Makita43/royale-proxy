using System.IO;

namespace Royale_Proxy
{
    internal class Logger
    {
        public Logger()
        {
            if (!Directory.Exists("Packets"))
                Directory.CreateDirectory("Packets");
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