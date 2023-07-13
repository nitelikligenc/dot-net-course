using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AuthController : ControllerBase
{ 
    private readonly IMapper _mapper;
    readonly IAuthService authService;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        this.authService = authService;
        _mapper = mapper;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> LoginUserAsync([FromBody] LoginRequestDto request)
    {
        var result = await authService.LoginUserAsync(request);

        return result;
    }
    
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<ActionResult> RegisterUserAsync([FromBody] UserRegisterDto request)
    {
        var user = _mapper.Map<User>(request);
        
        var result = await authService.RegisterUserAsync(user, request.Password);
        if (result.Succeeded)
        {
            return Ok("Hesabınız başarılı şekilde oluşturulmuştur.");
        }
        return BadRequest(result.Errors);
    }
    
    [HttpPost("Unlock/User/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> UnlockUserAsync(string id)
    {

        var result = await authService.UnlockUser(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
}