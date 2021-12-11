using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace OptionalValues.UsingEnumerable
{
    [DebuggerDisplay("{_data[0]}")]
    public class Option<T> : IEnumerable<T>, IOption<T>
    {
        public static readonly Option<T> None = new Option<T>(new T[0]);
        private readonly T[] _data;

        private Option(T[] data)
            => _data = data;

        public static Option<T> Create(T element)
            => null != element ? new Option<T>(new T[] { element }) : None;

        public bool IsNone
        {
            get => 0 == _data.Length;
        }

        public T GetValueOrDefault(T defaultValue)
            => IsNone ? defaultValue : _data[0];

        public IOption<U> Apply<U>(Func<T, U> apply)
        {
            if (IsNone)
                return Option<U>.None;

            return Option<U>.Create(apply(_data[0]));
        }

        public IOption<U> ApplyOption<U>(Func<T, IOption<U>> apply)
        {
            if (IsNone)
                return Option<U>.None;

            return apply(_data[0]);
        }

        public void Action(Action<T> action)
        {
            if (IsNone)
                return;

            action(_data[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this._data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
