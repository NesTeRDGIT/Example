namespace EmailService.Application.Use.Command.AddMessage
{
    /// <summary>
    /// Проекция получателя
    /// </summary>
    public class RecipientProjection
    {
        /// <summary>
        /// Имя получателя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес почты
        /// </summary>
        public string Email { get; set; }
    }
}
