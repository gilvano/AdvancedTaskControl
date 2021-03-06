using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedTaskControl.Business.Interfaces;
using AutoMapper;
using AdvancedTaskControl.API.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AdvancedTaskControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult<UserViewModel>> AddUser(UserViewModel userModelView)
        {            
            var user = _mapper.Map<User>(userModelView);

            if (!await _userService.Insert(user))
                return BadRequest("Usuário já existe!");

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _userService.GetAll();
        }

    }
}