using System.IO;
using System.Threading.Tasks;

namespace RechargeSharp.v2021_11.Tests.TestHelpers;

public class TestResourcesHelper
{
    public static string TestResourcesFolder = Path.GetRelativePath(Directory.GetCurrentDirectory(), "TestResources/");
    public static string SampleResponsesFolder = Path.Combine(TestResourcesFolder, "SampleResponses/");

    public static async Task<string> GetSampleResponseJson(string filePath)
    {
        var fullFilePath = Path.Combine(SampleResponsesFolder, filePath);
        var fileContents = await File.ReadAllTextAsync(fullFilePath);
        return fileContents;
    }
}