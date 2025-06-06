using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class SaveVerificationCodeRequest
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Code { get; set; } = null!;
    public TimeSpan ValidFor {  get; set; }
}
