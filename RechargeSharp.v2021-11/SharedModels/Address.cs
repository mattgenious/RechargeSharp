namespace RechargeSharp.v2021_11.SharedModels;

public record Address
{
    public string? Address1 { get; init; }
    public string? Address2 { get; init; }
    public string? City { get; init; }
    public string? Company { get; init; }
    public string? Country { get; init; }
    public string? CountryCode { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Phone { get; init; }
    public string? Province { get; init; }
    public string? Zip { get; init; }
}