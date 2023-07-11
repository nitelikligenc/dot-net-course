using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;

namespace NitelikliGenc.WebAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AuthController : ControllerBase
{ 
    readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> LoginUserAsync([FromBody] LoginRequestDto request)
    {
        var result = await authService.LoginUserAsync(request);

        return result;
    }
}