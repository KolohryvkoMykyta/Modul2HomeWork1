namespace Modul2HomeWork1
{
    public class Result
    {
        public Result(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public bool Status { get; private set; }

        public string Message { get; private set;  }
    }
}
