namespace Abstraction.Exception
{
    /// <summary>
    /// Исключение домена
    /// </summary>
    public abstract class DomainException : System.Exception
    {
        protected DomainException(string message) : base(message)
        {

        }
    }
}