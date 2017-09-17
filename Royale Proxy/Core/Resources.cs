namespace Royale_Proxy
{
    internal class Resources
    {
        public static Definition Definition;
        public static Logger Logger;
        public static Server Server;

        public Resources()
        {
            Definition = new Definition();

            Logger = new Logger();

            Server = new Server();
        }
    }
}