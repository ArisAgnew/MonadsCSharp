using System;

using static System.Console;

namespace AgnewMonad
{
    public sealed class IntContainer<T> : IMonad<int>
    {
        private static readonly object sync = new object();

        public int Value { get; }

        public IntContainer(in int value) => Value = value;
      
        public IMonad<int> Interlock(Func<int, IMonad<int>> func)
        {
            if (Value == default)
            {
                lock (sync)
                {
                    return new IntContainer<int>(default);
                }
            }
            return func(Value);
        }

        public IMonad<int> Depict()
        {
            WriteLine($"Full result of {nameof(IntContainer<int>)} monad type is: {Value}");
            return this as IntContainer<int> ?? default;
        }

        public static implicit operator IntContainer<T>(int value) => new IntContainer<T>(value);
        public static explicit operator int(IntContainer<T> intContainer) => intContainer.Value;
    }
}
