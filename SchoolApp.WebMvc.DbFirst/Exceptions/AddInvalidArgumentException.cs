namespace SchoolApp.WebMvcDbFirst.Exceptions
{
    public class AddInvalidArgumentException : AppException
    {
        private static readonly string DEFAULT_CODE = "InvalidArgument";

        public AddInvalidArgumentException(string code, string message) : base(code + DEFAULT_CODE, message)
        {
        }
    }
}
