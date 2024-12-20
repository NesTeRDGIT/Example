namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена - несоответствующие значения
    /// </summary>
    /// <remarks>
    /// Значение не соответствует текущему состоянию объекта - нарушение согласованности данных
    /// </remarks>
    public class InappropriateDomainException : DomainException
    {
        /// <summary>
        /// Несоответствующие значения
        /// </summary>
        /// <remarks>
        /// Значение не соответствует текущему состоянию объекта - нарушение согласованности данных
        /// </remarks>
        /// <param name="message">>Сообщение об ошибке, объясняющее причину исключения</param>
        public InappropriateDomainException(string message) : base(message)
        {
        }
    }
}