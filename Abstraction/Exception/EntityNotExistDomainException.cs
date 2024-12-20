namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена - сущность не существует
    /// </summary>
    /// <remarks>
    /// Обращение к сущности невозможно, т.к. Требуемая сущность не существует
    /// </remarks>
    public class EntityNotExistDomainException : DomainException
    {
        /// <summary>
        /// Сущность не существует
        /// </summary>
        /// <remarks>
        /// Обращение к сущности невозможно, т.к. требуемая сущность не существует
        /// </remarks>
        /// <param name="message">Сообщение об ошибке, объясняющее причину исключения</param>
        public EntityNotExistDomainException(string message) : base(message)
        {
        }
    }
}