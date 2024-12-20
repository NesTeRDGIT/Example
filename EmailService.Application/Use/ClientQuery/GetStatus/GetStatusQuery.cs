using Abstraction.CQRS.Query;

namespace EmailService.Application.Use.ClientQuery.GetStatus
{
    /// <summary>
    /// Запрос статусов сообщений
    /// </summary>
    public class GetStatusQuery : IQuery<GetStatusResponse>
    {
    }
}
