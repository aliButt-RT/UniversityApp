namespace UniversityApp.Models
{
    public class OperationResult
    {
        public bool Succeeded { get; }

        public bool Failed => !Succeeded;

        public string Message { get; }

        public object Payload { get; }

        public OperationResult(bool succeeded, string message, object payload = null)
        {
            Succeeded = succeeded;
            Message = message;
            Payload = payload;
        }
    }
}
