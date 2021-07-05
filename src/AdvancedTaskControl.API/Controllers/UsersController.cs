using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedTaskControl.Business.Interfaces;

namespace AdvancedTaskControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            await _userService.Insert(user);
          
            return Ok(user);
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