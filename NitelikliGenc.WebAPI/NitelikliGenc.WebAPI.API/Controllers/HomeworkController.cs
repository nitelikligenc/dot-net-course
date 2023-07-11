using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.WebAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class HomeworkController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public HomeworkController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("{text}/encyrpt")]
    public IActionResult Encrypt(string text)
    {
        var shiftKey = _configuration.GetValue<int>("ShiftKey");
        var encryptText = EncryptText(text, shiftKey);
        return Ok(encryptText);
    }

    [HttpPost("{text}/decrypt")]
    public IActionResult Decrypt(string text)
    {
        var shiftKey = _configuration.GetValue<int>("ShiftKey");
        var decryptText = DecryptText(text.ToUpper(), shiftKey);
        return Ok(decryptText);
    }

    private string EncryptText(string text, int shiftKey)
    {
        // MERHABA
        string encryptedText = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char encyrptedChar = (char) (((c - 'A') + shiftKey) % 26 + 'A') ;
                encryptedText += encyrptedChar;
            }
            else
            {
                encryptedText += c;
            }
        }
        return encryptedText;
    }

    private string DecryptText(string text, int shiftKey)
    {
        string decryptText = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                var decryptChar = (char) (((c - 'A') - shiftKey) % 26 + 'A');
                decryptText += decryptChar;
            }
            else
            {
                decryptText += c;
            }
        }
        return decryptText;
    }
}