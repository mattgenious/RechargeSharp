using RechargeSharp.v2021_11.SharedModels.Errors;

namespace RechargeSharp.v2021_11.Exceptions;

/// <summary>
///     The base class for all exceptions that might be thrown when calling the Recharge API
/// </summary>
public class RechargeApiException : Exception
{
    public ApiError? ErrorDataJson { get; }

    /// <summary>
    ///     * If true, the error is definitely transient.
    ///     * If false, the error is definitely not transient.
    ///     * If null, the error *might* be transient.
    /// </summary>
    public virtual bool? IsTransient => null; 
    
    public RechargeApiException(string message) : base(message)
    {
    }
    
    public RechargeApiException(ApiError? errorDataJson) : base(errorDataJson?.ToString() ?? "An error was returned without any structured error data")
    {
        ErrorDataJson = errorDataJson;
    }
    
    public RechargeApiException(string? message, ApiError? errorDataJson) : base(message)
    {
        ErrorDataJson = errorDataJson;
    }
}

/// <summary>
///     Thrown when response codes from Recharge indicates a server-side error
/// </summary>
public class RechargeApiServerException : RechargeApiException
{
    public RechargeApiServerException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class RateLimitingException : RechargeApiException
{
    public override bool? IsTransient => true;

    public RateLimitingException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class InvalidApiVersionException : RechargeApiException
{
    public override bool? IsTransient => false;
    public InvalidApiVersionException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}


public class UnprocessableEntityException  : RechargeApiException
{
    public override bool? IsTransient => false;
    public UnprocessableEntityException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class UnsupportedMediaTypeException : RechargeApiException
{
    public override bool? IsTransient => false;
    public UnsupportedMediaTypeException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class UnknownApiFailureException : RechargeApiException
{
    public UnknownApiFailureException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class ConflictException : RechargeApiException
{
    public ConflictException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class UnauthorizedException : RechargeApiException
{
    public override bool? IsTransient => false;
    public UnauthorizedException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class ForbiddenException : RechargeApiException
{
    public override bool? IsTransient => false;
    public ForbiddenException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class NotFoundException : RechargeApiException
{
    public override bool? IsTransient => false;
    public NotFoundException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class MethodNotAllowedException : RechargeApiException
{
    public override bool? IsTransient => false;
    public MethodNotAllowedException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class BadRequestException : RechargeApiException
{
    public override bool? IsTransient => false;
    public BadRequestException(ApiError? errorDataJson) : base(errorDataJson)
    {
    }
}

public class UnexpectedResponseContentException : RechargeApiException
{
    public UnexpectedResponseContentException(string message) : base(message)
    {
    }
}

