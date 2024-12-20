using Abstraction.CQRS.Query;

namespace EmailService.Application.Use.ClientQuery.GetStatus
{
    /// <summary>
    /// Обработчик запроса статусов сообщений
    /// </summary>
    public interface IGetStatusQueryHandler : IQueryHandler<GetStatusQuery, GetStatusResponse>
    {
    }
}
