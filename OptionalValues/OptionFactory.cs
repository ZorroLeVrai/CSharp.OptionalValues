using System;

namespace OptionalValues
{
    public enum OptionType
    {
        UsingEnumerable,
        UsingStruct
    }

    public interface IOptionFactory
    {
        IOption<T> Create<T>(T element);

        IOption<T> CreateEmpty<T>();
    }

    public class OptionEnumerableFactory : IOptionFactory
    {
        public IOption<T> Create<T>(T element)
        {
            return OptionalValues.UsingEnumerable.Option<T>.Create(element);
        }

        public IOption<T> CreateEmpty<T>()
        {
            return OptionalValues.UsingEnumerable.Option<T>.None;
        }
    }


    public class OptionStructFactory : IOptionFactory
    {
        public IOption<T> Create<T>(T element)
        {
            return OptionalValues.UsingStruct.Option<T>.Create(element);
        }

        public IOption<T> CreateEmpty<T>()
        {
            return OptionalValues.UsingStruct.Option<T>.None;
        }
    }

    public class OptionFactory
    {
        public static IOptionFactory Create(OptionType factoryType)
        {
            switch (factoryType)
            {
                case OptionType.UsingEnumerable:
                    return new OptionEnumerableFactory();
                case OptionType.UsingStruct:
                    return new OptionStructFactory();
                default:
                    throw new Exception("Bad factory type");
            }
        }
    }
}
