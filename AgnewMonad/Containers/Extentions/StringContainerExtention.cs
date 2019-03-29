using System;
using System.Text;

namespace AgnewMonad
{
    public abstract class StringContainerExtention<T>
    {
        public StringContainerExtention() { }
        public StringContainerExtention(in StringBuilder stringBuilder) => StringBuilder = stringBuilder;

        public virtual StringBuilder StringBuilder { get; set; }
        public virtual StringContainerExtention<T> Interlock(Func<StringBuilder, StringContainerExtention<T>> func) => default;
    }
}
