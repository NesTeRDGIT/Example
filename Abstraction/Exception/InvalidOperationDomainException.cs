namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена - недопустимая операция
    /// </summary>
    /// <remarks>
    /// Операция не может быть выполнена в текущем состоянии объекта
    /// </remarks>
    public class InvalidOperationDomainException : DomainException
    {
        /// <summary>
        /// Недопустимая операция
        /// </summary>
        /// <remarks>
        /// Операция не может быть выполнена в текущем состоянии объекта
        /// </remarks>
        /// <param name="message">Сообщение об ошибке, объясняющее причину исключения</param>
        public InvalidOperationDomainException(string message) : base(message)
        {
        }
    }
}