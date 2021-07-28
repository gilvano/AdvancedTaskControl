using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.API.ViewModels;
using AdvancedTaskControl.Business.Interfaces;
using AutoMapper;
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
        private readonly IUserLoginService _userLoginService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginController(IUserLoginService userLoginService, ITokenService tokenService, IMapper mapper)
        {
            _userLoginService = userLoginService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody]UserLoginModelView userLogin)
        {
            var user = _mapper.Map<User>(userLogin);

            user = await _userLoginService.Authenticate(user);
            
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
