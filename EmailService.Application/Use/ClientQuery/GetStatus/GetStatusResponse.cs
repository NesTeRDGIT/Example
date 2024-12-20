using Abstraction.CQRS;

namespace EmailService.Application.Use.ClientQuery.GetStatus
{
    /// <summary>
    /// Ответ на запрос статусов сообщений
    /// </summary>
    public class GetStatusResponse : IResponse
    {
        /// <summary>
        /// Статусы
        /// </summary>
        public IList<StatusProjection> Statuses { get; set; }
    }
}
