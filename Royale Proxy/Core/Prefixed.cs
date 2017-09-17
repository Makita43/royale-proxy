using System;
using System.IO;
using System.Text;

namespace Royale_Proxy
{
    internal class Prefixed : TextWriter
    {
        public readonly TextWriter _Original;

        public Prefixed()
        {
            _Original = Console.Out;
        }

        public override Encoding Encoding => new ASCIIEncoding();

        public override void Write(string _Text)
        {
            _Original.Write(_Text);
        }

        public override void WriteLine(string _Text)
        {
            _Original.WriteLine($"[+]    {_Text}");
        }

        public override void WriteLine()
        {
            _Original.WriteLine();
        }
    }
}