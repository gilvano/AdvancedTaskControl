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

namespace AdvancedTaskControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<User>> AddUser(User user)
        {
            await _userService.Insert(user);

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return Ok(userViewModel);
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
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _userService.GetAll();
        }

    }
}