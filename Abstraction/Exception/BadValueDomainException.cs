namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена - значение некорректно
    /// </summary>
    /// <remarks>
    /// Значение не соответствует ожидаемому типу или формату
    /// </remarks>
    public class BadValueDomainException : DomainException
    {
        /// <summary>
        /// Значение некорректно
        /// </summary>
        /// <remarks>
        /// Значение не соответствует ожидаемому типу или формату
        /// </remarks>
        /// <param name="message">Сообщение об ошибке, объясняющее причину исключения</param>
        /// <param name="paramName">Имя параметра, вызвавшего исключение</param>
        /// <param name="value">Некорректное значение параметра</param>
        public BadValueDomainException(string message, string paramName = null, object value = null) : base(message)
        {
            this.Value = value;
            this.ParamName = paramName;
        }

        /// <summary>
        /// Имя параметра
        /// </summary>
        public string ParamName { get; }

        /// <summary>
        /// Некорректное значение
        /// </summary>
        public object Value { get; }
    }
}