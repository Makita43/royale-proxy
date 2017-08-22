// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;

    class Program
    {
        public static string Hostname = "game.clashroyaleapp.com";
        public static int Port = 9339;

        static readonly Prefixed Prefixed = new Prefixed();

        public static void Main(string[] args)
        {
            Console.Title = "Royale Proxy | 1.0.0";

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
    }
}