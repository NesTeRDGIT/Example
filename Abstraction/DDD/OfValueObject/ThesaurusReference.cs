namespace Abstraction.DDD.OfValueObject
{
    /// <summary>
    /// Элемент справочника по Thesaurus
    /// <para>Базовый класс</para>
    /// </summary>
    /// <typeparam name="T">Тип элемента справочника</typeparam>
    /// <typeparam name="TValue">Тип значения элемента</typeparam>
    public abstract class ThesaurusReference<T, TValue> : ValueObject<T>
        where T : ThesaurusReference<T, TValue>
    {
        private readonly EqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;

        /// <summary>
        /// Значение
        /// </summary>
        public TValue Value { get; protected set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Значение некорректно
        /// </summary>
        public bool IsIncorrect { get; private set; }

        /// <summary>
        /// Заменить элемент на некорректный со значением value, если элемент является дефолтным для данного типа
        /// </summary>
        /// <param name="value">Некорректное значение. Если null, замена не происходит</param>
        public T TryReplaceDefaultWithIncorrect(TValue value)
        {
            if (this == GetDefault() && value != null)
            {
                Value = value;
                Name = "Некорректное значение";
                IsIncorrect = true;
            }
            return (T)this;
        }

        /// <summary>
        /// Получить значение по умолчанию для данного типа
        /// </summary>
        /// <returns></returns>
        public abstract T GetDefault();

        protected override bool CompareValues(T other)
        {
            return valueComparer.Equals(Value, other.Value);
        }

        protected override int GetValueHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
