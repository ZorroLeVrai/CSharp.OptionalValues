using System;

namespace OptionalValues.UsingStruct
{
    public struct Option<T> : IOption<T>
    {
        public static readonly Option<T> None = new Option<T>(default, true);

        private readonly T _data;

        public bool IsNone { get; }

        private Option(T data, bool isNone)
        {
            _data = data;
            IsNone = isNone;
        }

        public static IOption<T> Create(T element)
            => null != element ? new Option<T>(element, false) : None;

        public T GetValueOrDefault(T defaultValue)
            => IsNone ? defaultValue : _data;

        public IOption<U> Apply<U>(Func<T, U> apply)
        {
            if (IsNone)
                return Option<U>.None;

            return Option<U>.Create(apply(_data));
        }

        public IOption<U> ApplyOption<U>(Func<T, IOption<U>> apply)
        {
            if (IsNone)
                return Option<U>.None;

            return apply(_data);
        }

        public void Action(Action<T> action)
        {
            if (IsNone)
                return;

            action(_data);
        }
    }
}
