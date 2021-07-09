using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.API.ViewModels;
using AdvancedTaskControl.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate(UserLoginModelView userLogin)
        {
            var users = await _userService.GetAll();
            var user = users.ToList()
                .Where(u => u.Username.ToLower() == userLogin.Username.ToLower() && u.Password == userLogin.Password)
                .FirstOrDefault();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);
            user.Password = "";
            return Ok(new
            {
                user = user,
                token = token
            });
        }
    }
}
