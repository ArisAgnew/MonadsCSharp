using System;
using System.Text;

using static System.Console;

namespace AgnewMonad
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * The solution by using a struct is actually more fine-drawn & shorter as compared with using a class. 
             * There is no need to create an instance using a struct.
             */
            {
                var _intStruct = ((IntStruct)new Func<int>(() => 10)())
                    .Interlock(v => v + 10)
                    .Interlock(v => v * 4)
                    .Interlock(v => v + (v * 1 / 4))
                    .Depict();
            }

            {
                var _int = new IntContainer<int>(10)
                    .Interlock(v => new IntContainer<int>(v + 10))
                    .Interlock(v => new IntContainer<int>(v * 4))
                    .Interlock(v => new IntContainer<int>(v + (v * 1 / 4)))
                    .Depict();
            }

            {
                var _string = new StringContainer<string>(new StringBuilder("They will all"))
                    .Interlock(v => new StringContainer<string>(v.Append(" ").Append("cease")))
                    .Interlock(v => new StringContainer<string>(v.Append(" ").Append("to exist")));

                WriteLine(_string.StringBuilder.ToString());
            }
            
            Read();
        }
    }
}
