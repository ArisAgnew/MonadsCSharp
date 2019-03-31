using System;

namespace AgnewMonad
{
    public sealed class ObjectContainer<T> : IMonad<object>
    {
        private static readonly object sync = new object();

        public object Value { get; }

        public ObjectContainer(in object value) => Value = value;

        public IMonad<object> Interlock(Func<object, IMonad<object>> func)
        {
            if (Value == default)
            {
                lock (sync)
                {
                    return new ObjectContainer<object>(default);
                }
            }
            return func(Value);
        }

        public IMonad<object> Depict()
        {
            throw new NotImplementedException();
        }
    }
}
