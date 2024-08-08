namespace AppGestion.Application.Models.Common;

public class OperationResult<TResult>
{
    public TResult? Result { get; private set; }
    public bool IsSuccess { get; private set; }
    public string? ErrorMessage { get; private set; }
    public bool IsException { get; set; }
    public bool IsNotFound { get; private set; }
    
    public static OperationResult<TResult> SuccessResult(TResult result) => new() { Result = result,IsSuccess = true};
    
    public static OperationResult<TResult?> FailureResult(string message,TResult? result=default) => new() {Result = result,ErrorMessage = message,IsSuccess = false};
    
    public static OperationResult<TResult> NotFoundResult(string message) => new() { ErrorMessage = message, IsSuccess = false, IsNotFound = true };
}