using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
/// Error from response.
/// </summary>
public sealed class Error
{
    /// <summary>
    /// Create instance of <see cref="Error"/>.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="name"></param>
    public Error(int code, string name)
    {
        this.Code = code;
        this.Name = name;
    }

    [JsonConstructor]
    private Error() {}

    /// <summary>
    /// Error code from response.
    /// </summary>
    [JsonRequired]
    public int Code { get; set; }

    /// <summary>
    /// Error name from response.
    /// </summary>
    [JsonRequired]
    public string Name { get; set; }
}