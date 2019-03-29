using System;
using System.Text;

namespace AgnewMonad
{
    public sealed class StringContainer<T> : StringContainerExtention<string>, IMonad<string>
    {
        private static readonly object sync = new object();

        public string Value { get; }

        public StringContainer(in string value) => Value = value;
        public StringContainer(in StringBuilder strBuilder) : base(strBuilder) { }

        public IMonad<string> Interlock(Func<string, IMonad<string>> func)
        {
            if (Value == default)
            {
                lock (sync)
                {
                    return new StringContainer<string>(default(string));
                }
            }
            return func(Value);
        }

        public override StringContainerExtention<string> Interlock(Func<StringBuilder, StringContainerExtention<string>> func)
        {
            if (StringBuilder == default)
            {
                lock (sync)
                {
                    return new StringContainer<string>(default(string));
                }
            }
            return func(StringBuilder);
        }

        public static implicit operator StringContainer<T>(string value) => new StringContainer<T>(value);
        public static explicit operator string(StringContainer<T> stringContainer) => stringContainer.Value;
    }
}
