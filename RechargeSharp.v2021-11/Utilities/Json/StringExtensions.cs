namespace RechargeSharp.v2021_11.Utilities.Json;

public static class StringExtensions
{
    /// <summary>
    ///     From: https://www.michaelrose.dev/posts/exploring-system-text-json/
    /// </summary>
    public static string ToSnakeCase(this string str)
    {
        var upperCaseLength = str.Count(t => t >= 'A' && t <= 'Z' && t != str[0]);
        var bufferSize = str.Length + upperCaseLength;
        Span<char> buffer = new char[bufferSize];
        var bufferPosition = 0;
        var namePosition = 0;
        while (bufferPosition < buffer.Length)
        {
            if (namePosition > 0 && str[namePosition] >= 'A' && str[namePosition] <= 'Z')
            {
                buffer[bufferPosition] = '_';
                buffer[bufferPosition + 1] = str[namePosition];
                bufferPosition += 2;
                namePosition++;
                continue;
            }

            buffer[bufferPosition] = str[namePosition];
            bufferPosition++;
            namePosition++;
        }

        return new string(buffer).ToLower();
    }
}