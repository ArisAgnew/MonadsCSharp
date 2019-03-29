using System;

namespace AgnewMonad
{
    public interface IMonad<T>
    {
        T Value { get; }

        IMonad<T> Interlock(Func<T, IMonad<T>> func);
    }
}
