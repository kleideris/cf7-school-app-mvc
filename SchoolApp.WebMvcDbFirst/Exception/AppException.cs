namespace SchoolApp.WebMvcDbFirst.Exception
{
    public abstract class AppException : System.Exception
    {
        public string Code { get; set; }

        protected AppException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}


