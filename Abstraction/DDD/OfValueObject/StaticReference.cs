using System.Reflection;
using Abstraction.Exception;

namespace Abstraction.DDD.OfValueObject
{
    /// <summary>
    /// Элемент справочника с встроенным в тип статическим перечислением возможных элементов
    /// <para>Базовый класс</para>
    /// </summary>
    /// <typeparam name="T">Тип элемента справочника</typeparam>
    /// <typeparam name="TValue">Тип значения элемента</typeparam>
    public abstract class StaticReference<T, TValue> : ValueObject<T>
        where T : StaticReference<T, TValue>
        where TValue : IEquatable<TValue>
    {
        /// <summary>
        /// Список элементов справочника
        /// </summary>
        private static Dictionary<TValue, PropertyInfo> values;

        /// <summary>
        /// Значение
        /// </summary>
        public TValue Value { get; protected set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Получить коллекцию значений
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> GetAll() => GetValues().Values.Select(v => (T)v.GetValue(null));

        /// <summary>
        /// Получить элемент по значению
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Найденный элемент</returns>
        public static T Get(TValue value)
        {
            if (!GetValues().TryGetValue(value, out var t))
                throw new BadValueDomainException($"Значение {value} не найдено в справочнике {typeof(T).Name}", nameof(value), value);

            return (T)t.GetValue(null);
        }

        /// <summary>
        /// Получить элемент по значению
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="defaultValue">Элемент по умолчанию</param>
        /// <returns>Найденный элемент, или элемент по умолчанию, если значение отсутствует в справочнике</returns>
        public static T Get(TValue value, T defaultValue)
        {
            if (!GetValues().TryGetValue(value, out var t))
                return defaultValue;

            return (T)t.GetValue(null);
        }

        private static Dictionary<TValue, PropertyInfo> GetValues()
        {
            return values ??= typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(x => x.PropertyType == typeof(T))
                .ToDictionary(k => ((T)k.GetValue(null))!.Value, v => v);
        }

        protected override bool CompareValues(T other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetValueHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
