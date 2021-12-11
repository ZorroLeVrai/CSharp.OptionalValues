using System;

namespace OptionalValues
{
    public interface IOption<T>
    {
        /// <summary>
        /// If true the value is None
        /// </summary>
        bool IsNone { get; }

        /// <summary>
        /// Perform an action on the current object
        /// </summary>
        /// <param name="action"></param>
        void Action(Action<T> action);

        /// <summary>
        /// Apply a method that returns an Option
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apply"></param>
        /// <returns></returns>
        IOption<U> ApplyOption<U>(Func<T, IOption<U>> apply);

        /// <summary>
        /// Apply a method that does not return an Option
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apply"></param>
        /// <returns></returns>
        IOption<U> Apply<U>(Func<T, U> apply);

        /// <summary>
        /// Get the Option value
        /// </summary>
        /// <param name="defaultValue">the default value in case the Option does not have a value</param>
        /// <returns></returns>
        T GetValueOrDefault(T defaultValue);
    }
}