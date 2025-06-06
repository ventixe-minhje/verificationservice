namespace Presentation.Models;

public class VerificationServiceResult
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}
