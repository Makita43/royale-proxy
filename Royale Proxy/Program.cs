using System;
using System.Runtime.InteropServices;

namespace Royale_Proxy
{
    internal class Program
    {
        public static string Hostname = "game.clashroyaleapp.com";
        public static int Port = 9339;

        private static readonly Prefixed Prefixed = new Prefixed();

        public static void Main(string[] args)
        {
            Console.Title = "Royale Proxy | 1.0.1";

            var Handle = GetConsoleWindow();
            ShowWindow(Handle, 3);
            SetWindowLong(Handle, -20, (int) GetWindowLong(Handle, -20) ^ 0x80000);
            SetLayeredWindowAttributes(Handle, 0, 227, 0x2);

            Console.WriteLine(
                @"
      __________                        .__          __________                                
      \______   \  ____  ___.__._____   |  |    ____ \______   \_______   ____ ___  ___ ___.__.
       |       _/ /  _ \<   |  |\__  \  |  |  _/ __ \ |     ___/\_  __ \ /  _ \\  \/  /<   |  |
       |    |   \(  <_> )\___  | / __ \_|  |__\  ___/ |    |     |  | \/(  <_> )>    <  \___  |
       |____|_  / \____/ / ____|(____  /|____/ \___  >|____|     |__|    \____//__/\_ \ / ____|
              \/         \/          \/            \/                                \/ \/     ");

            Console.WriteLine();

            Console.SetOut(Prefixed);

            Console.WriteLine("Starting...");

            new Resources();

            Console.ReadKey(true);
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        internal static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
    }
}