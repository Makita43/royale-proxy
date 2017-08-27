// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;
    using System.IO;
    using System.Text;

    class Prefixed : TextWriter
    {
        public readonly TextWriter _Original;

        public Prefixed()
        {
            this._Original = Console.Out;
        }

        public override Encoding Encoding => new ASCIIEncoding();        

        public override void Write(string _Text)
        {
            this._Original.Write(_Text);
        }

        public override void WriteLine(string _Text)
        {
            this._Original.WriteLine($"[+]    {_Text}");
        }

        public override void WriteLine()
        {
            this._Original.WriteLine();
        }
    }
}