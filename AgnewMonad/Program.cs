using System;
using System.Text;

namespace AgnewMonad
{
    class Program
    {
        static void Main(string[] args)
        {
            var _int = new IntContainer<int>(10)
                .Interlock(v => new IntContainer<int>(v + 10))
                .Interlock(v => new IntContainer<int>(v * 4))
                .Interlock(v => new IntContainer<int>(v + (v * 1/4)));

            var _string = new StringContainer<string>(new StringBuilder("They will all"))
                .Interlock(v => new StringContainer<string>(v.Append(" ").Append("cease")))
                .Interlock(v => new StringContainer<string>(v.Append(" ").Append("to exist")));

            Console.WriteLine(_int.Value);
            Console.WriteLine(_string.StringBuilder.ToString());

            Console.Read();
        }
    }
}
