namespace RechargeSharp.v2021_11.Utilities.Json;

public static class StringExtensions
{
    /// <summary>
    ///     Inspired by: https://www.michaelrose.dev/posts/exploring-system-text-json/
    /// </summary>
    public static string ToSnakeCase(this string str)
    {
        // We don't care if the first letter is upper-cased or not
        var amountOfUpperCaseChars = str.Skip(1).Count(t => t is >= 'A' and <= 'Z');
        var bufferSize = str.Length + amountOfUpperCaseChars;
        Span<char> buffer = new char[bufferSize];
        var bufferPosition = 0;
        var namePosition = 0;
        while (bufferPosition < buffer.Length)
        {
            if (namePosition > 0 && str[namePosition] >= 'A' && str[namePosition] <= 'Z')
            {
                buffer[bufferPosition] = '_';
                buffer[bufferPosition + 1] = char.ToLower(str[namePosition]);
                bufferPosition += 2;
                namePosition++;
                continue;
            }

            buffer[bufferPosition] = char.ToLower(str[namePosition]);
            bufferPosition++;
            namePosition++;
        }

        return new string(buffer);
    }
}