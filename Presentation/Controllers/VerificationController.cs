using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VerificationController(IVerificationService verificationService) : ControllerBase
{
    private readonly IVerificationService _verificationService = verificationService;

    [HttpPost("send")]
    public async Task<IActionResult> Send(SendVerificationCodeRequest request)
    {
        if (!ModelState.IsValid) 
            return BadRequest(new { Error = "Recipient email adress is required." });

        var result = await _verificationService.SendVerificationCodeAsync(request);
        return result.Succeeded ? Ok(result) : StatusCode(500, result); 
    }

    [HttpPost("verify")]
    public IActionResult Verify(VerifyVerificationCodeRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { Error = "Invalid or expired code." });

        var result = _verificationService.VerifyVerificationCode(request);
        return result.Succeeded ? Ok(result) : StatusCode(500, result);
    }
}
