using System;
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

    /// <summary>
    /// Create instance of <see cref="Error"/>.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="name"></param>
    /// <param name="message"></param>
    public Error(int code, string name, string message)
    {
        this.Code = code;
        this.Name = name;
        this.Message = message;
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

    /// <summary>
    /// Error message from response.
    /// </summary>
    public string Message { get; set; }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        return obj is Error error && Code == error.Code && Name == error.Name && Message == error.Message;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Name, Message);
    }
}