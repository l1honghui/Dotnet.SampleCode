using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace JwtSample.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 添加Authorize标签的controller会检查是否存在认证身份信息，如果没有自动跳转Account/Login.
        /// 为了方便，默认在Account/Login方法里实现了Cookie认证信息，实现登录过程
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Login()
        {
            // todo 认证用户身份信息是否正确

            // 认证成功
            // 定义身份信息
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"lihonghui"),
                new Claim(ClaimTypes.Role,"admin"),
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdentity));
            return Ok();
        }

        /// <summary>
        /// 实现注销，清除Cookie
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
