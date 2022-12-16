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
        public static OperationResult Success() => new OperationResult(true, null);

        public static OperationResult Success(string message, object payload = null) => new OperationResult(true, message, payload);

        public static OperationResult Failure(string message, object payload = null) => new OperationResult(false, message, payload);

        public static OperationResult Forbid(string message, object payload = null) => new OperationResult(false, message, payload);
    }
}
