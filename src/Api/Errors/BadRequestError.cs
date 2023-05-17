namespace Api.Errors
{
    public class BadRequestError : Exception
    {
        public BadRequestError() : base() { }
        public BadRequestError(string message) : base(message) { }
        public BadRequestError(string message, Exception inner) : base(message, inner) { }
    }
}