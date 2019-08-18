using JwtSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtSample.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        public AuthorizeController(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        /// <summary>
        /// 模拟登录获取Token
        /// </summary>
        /// <param name="loginInputDto"></param>
        /// <returns></returns>
        [HttpGet("token")]
        public ActionResult<string> Get(LoginInputDto loginInputDto)
        {
            if (ModelState.IsValid)
            {
                if (loginInputDto.UserName == "lihonghui" && loginInputDto.Password == "123")
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "lihonghui"),
                        new Claim(ClaimTypes.Role, "admin")
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

                    var credit = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, null,
                        DateTime.UtcNow.AddMinutes(30), credit);
                    return Ok(new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
            }

            return BadRequest();
        }

    }
}
