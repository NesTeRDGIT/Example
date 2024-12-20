namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена - отсутствует значение
    /// </summary>
    /// <remarks>
    /// Отсутствует значение для параметра, который должен иметь значение
    /// </remarks>
    public class NoValueDomainException : DomainException
    {
        /// <summary>
        /// Отсутствует значение
        /// </summary>
        /// <remarks>
        /// Отсутствует значение для параметра, который должен иметь значение
        /// </remarks>
        /// <param name="message">Сообщение об ошибке, объясняющее причину исключения</param>
        /// <param name="paramName">Имя параметра, вызвавшего исключение</param>
        public NoValueDomainException(string message, string paramName = null) : base(message)
        {
            ParamName = paramName;
        }

        /// <summary>
        /// Имя параметра
        /// </summary>
        public string ParamName { get; }
    }
}