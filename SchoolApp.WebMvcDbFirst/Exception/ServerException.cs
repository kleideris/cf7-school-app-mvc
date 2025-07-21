namespace SchoolApp.WebMvcDbFirst.Exception
{
    public class ServerException : AppException
    {
        public ServerException(string code, string message) : base(code, message)
        {
        }
    }
}
