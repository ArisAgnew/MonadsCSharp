using System;

namespace AgnewMonad
{
    public interface IGlobalMonad<T>
    {
        IGlobalMonad<R> Interlock<R>(Func<T, IGlobalMonad<R>> func);
        IGlobalMonad<T> Interlock(Func<T, IGlobalMonad<T>> func);
        IGlobalMonad<T> Build();
    }
}
