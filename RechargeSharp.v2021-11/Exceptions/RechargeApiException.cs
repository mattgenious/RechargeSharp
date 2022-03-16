using RechargeSharp.v2021_11.SharedModels.Errors;

namespace RechargeSharp.v2021_11.Exceptions;

/// <summary>
///     The base class for all exceptions that might be thrown when calling the Recharge API
/// </summary>
public class RechargeApiException : Exception
{
    public ApiError? ErrorData { get; }

    /// <summary>
    ///     * If true, the error is definitely transient.
    ///     * If false, the error is definitely not transient.
    ///     * If null, the error *might* be transient.
    /// </summary>
    public virtual bool? IsTransient => null; 
    
    public RechargeApiException(string message) : base(message)
    {
    }
    
    public RechargeApiException(ApiError? errorData) : base(errorData?.ToString() ?? "An error was returned without any structured error data")
    {
        ErrorData = errorData;
    }
    
    public RechargeApiException(string? message, ApiError? errorData) : base(message)
    {
        ErrorData = errorData;
    }
}

/// <summary>
///     Thrown when response codes from Recharge indicates a server-side error
/// </summary>
public class RechargeApiServerException : RechargeApiException
{
    public RechargeApiServerException(ApiError? errorData) : base(errorData)
    {
    }
}

public class RateLimitingException : RechargeApiException
{
    public override bool? IsTransient => true;

    public RateLimitingException(ApiError? errorData) : base(errorData)
    {
    }
}

public class InvalidApiVersionException : RechargeApiException
{
    public override bool? IsTransient => false;
    public InvalidApiVersionException(ApiError? errorData) : base(errorData)
    {
    }
}


public class UnprocessableEntityException  : RechargeApiException
{
    public override bool? IsTransient => false;
    public UnprocessableEntityException(ApiError? errorData) : base(errorData)
    {
    }
}

public class UnsupportedMediaTypeException : RechargeApiException
{
    public override bool? IsTransient => false;
    public UnsupportedMediaTypeException(ApiError? errorData) : base(errorData)
    {
    }
}

public class UnknownApiFailureException : RechargeApiException
{
    public UnknownApiFailureException(ApiError? errorData) : base(errorData)
    {
    }
}

public class ConflictException : RechargeApiException
{
    public ConflictException(ApiError? errorData) : base(errorData)
    {
    }
}

public class UnauthorizedException : RechargeApiException
{
    public override bool? IsTransient => false;
    public UnauthorizedException(ApiError? errorData) : base(errorData)
    {
    }
}

public class ForbiddenException : RechargeApiException
{
    public override bool? IsTransient => false;
    public ForbiddenException(ApiError? errorData) : base(errorData)
    {
    }
}

public class NotFoundException : RechargeApiException
{
    public override bool? IsTransient => false;
    public NotFoundException(ApiError? errorData) : base(errorData)
    {
    }
}

public class MethodNotAllowedException : RechargeApiException
{
    public override bool? IsTransient => false;
    public MethodNotAllowedException(ApiError? errorData) : base(errorData)
    {
    }
}

public class BadRequestException : RechargeApiException
{
    public override bool? IsTransient => false;
    public BadRequestException(ApiError? errorData) : base(errorData)
    {
    }
}

public class UnexpectedResponseContentException : RechargeApiException
{
    public UnexpectedResponseContentException(string message) : base(message)
    {
    }
}

