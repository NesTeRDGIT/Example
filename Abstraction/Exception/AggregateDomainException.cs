namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена - набор исключений
    /// </summary>
    /// <remarks>
    /// Множество ошибок
    /// </remarks>
    public class AggregateDomainException : DomainException
    {
        /// <summary>
        /// Отсутствует значение
        /// </summary>
        /// <remarks>
        /// Отсутствует значение для параметра, который должен иметь значение
        /// </remarks>
        /// <param name="message">Сообщение об ошибке, объясняющее причину исключения</param>
        /// <param name="exceptions">Набор исключений</param>
        public AggregateDomainException(string message, IEnumerable<DomainException> exceptions) : base(message)
        {
            Exceptions = exceptions;
        }

        /// <summary>
        /// Исключения
        /// </summary>
        public IEnumerable<DomainException> Exceptions { get; }
    }
}
