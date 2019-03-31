using System;

using static System.Console;

namespace AgnewMonad
{
    public struct IntStruct
    {
        private static readonly object sync = new object();

        public int Value { get; }

        public IntStruct(in int value) => this.Value = value;

        public IntStruct Interlock(Func<int, IntStruct> func)
        {
            if (Value == default)
            {
                lock (sync)
                {
                    return new IntStruct(default);
                }
            }
            return func(Value);
        }

        public IntStruct Depict()
        {
            WriteLine($"Full result of {nameof(IntStruct)} monad type is: {Value}");
            return this;
        }

        public static implicit operator IntStruct(int value) => new IntStruct(value);
        public static explicit operator int(IntStruct intContainer) => intContainer.Value;
    }
}
