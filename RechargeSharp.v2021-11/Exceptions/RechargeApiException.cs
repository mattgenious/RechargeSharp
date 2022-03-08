using RechargeSharp.v2021_11.Entities;

namespace RechargeSharp.v2021_11.Exceptions;

/// <summary>
///     The base class for all exceptions that can be thrown when calling the Recharge API
/// </summary>
public class RechargeApiException : Exception
{
    public ApiError? StructuredApiErrorData { get; }
    
    public RechargeApiException(string message) : base(message)
    {
    }
    
    public RechargeApiException(ApiError? structuredApiErrorData) : base(structuredApiErrorData?.ToString() ?? "An error was returned without any structured error data")
    {
        StructuredApiErrorData = structuredApiErrorData;
    }
    
    public RechargeApiException(string? message, ApiError? structuredApiErrorData) : base(message)
    {
        StructuredApiErrorData = structuredApiErrorData;
    }
}

/// <summary>
///     Thrown when response codes from Recharge indicates a server-side error
/// </summary>
public class RechargeApiServerException : RechargeApiException
{
    public RechargeApiServerException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class RateLimitingException : RechargeApiException
{
    public RateLimitingException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class InvalidApiVersionException : RechargeApiException
{
    public InvalidApiVersionException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}


public class UnprocessableEntityException  : RechargeApiException
{
    public UnprocessableEntityException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class UnsupportedMediaTypeException : RechargeApiException
{
    public UnsupportedMediaTypeException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class UnknownApiFailureException : RechargeApiException
{
    public UnknownApiFailureException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class ConflictException : RechargeApiException
{
    public ConflictException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class UnauthorizedException : RechargeApiException
{
    public UnauthorizedException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class ForbiddenException : RechargeApiException
{
    public ForbiddenException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class NotFoundException : RechargeApiException
{
    public NotFoundException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class MethodNotAllowedException : RechargeApiException
{
    public MethodNotAllowedException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class BadRequestException : RechargeApiException
{
    public BadRequestException(ApiError? structuredApiErrorData) : base(structuredApiErrorData)
    {
    }
}

public class UnexpectedResponseContentException : RechargeApiException
{
    public UnexpectedResponseContentException(string message) : base(message)
    {
    }
}

