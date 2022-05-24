namespace RechargeSharp.v2021_11.SharedModels;

public record AnalyticsData
{
    public IReadOnlyList<UtmParam>? UtmParams { get; init; }
}