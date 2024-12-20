namespace EmailService.Application.Use.Command.AddMessage
{
    /// <summary>
    /// Проекция вложения
    /// </summary>
    public class AttachmentProjection
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        public byte[] Data { get; set; }
    }
}
