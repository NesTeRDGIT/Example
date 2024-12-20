using EmailService.Application.Use.ClientQuery.GetMessageListItem;

namespace EmailService.Application.Persistence.QueryObject.ClientQuery
{
    /// <summary>
    /// Объект запроса сообщений
    /// </summary>
    public interface IGetMessageListItemQueryObject
    {
        /// <summary>
        /// Получить элементы списка обращений
        /// </summary>
        /// <param name="lightReadParams">Параметры чтения</param>
        /// <param name="email">Поиск по почте</param>
        Task<List<MessageProjection>> GetAsync(LightReadParams<MessageProjection> lightReadParams, string email);

        /// <summary>
        /// Получить количество элементов
        /// </summary>
        /// <param name="lightReadParams">Параметры чтения</param>
        /// <param name="email">Поиск по почте</param>
        Task<long> CountAsync(LightReadParams<MessageProjection> lightReadParams, string email);
    }
}
