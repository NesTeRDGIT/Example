namespace Abstraction.DDD.OfEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности
    /// </summary>
    public interface IEntityId : IEquatable<IEntityId>
    {
        /// <summary>
        /// Значение
        /// </summary>
        public long Value { get; }
    }
}
