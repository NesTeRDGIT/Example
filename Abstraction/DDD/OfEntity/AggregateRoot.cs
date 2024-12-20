namespace Abstraction.DDD.OfEntity
{
    /// <summary>
    /// Корень агрегата
    /// <para>Базовый класс</para>
    /// </summary>
    public class AggregateRoot<TId> : Entity<TId> where TId : IEntityId
    {
    }
}
