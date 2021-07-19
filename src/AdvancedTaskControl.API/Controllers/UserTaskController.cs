using AdvancedTaskControl.API.ViewModels;
using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;
        private readonly IMapper _mapper;

        public UserTaskController(IUserTaskService userTaskService, IMapper mapper)
        {
            _userTaskService = userTaskService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UserViewModel>> AddUser(UserViewModel userTaskModelView)
        {
            var userTask = _mapper.Map<UserTask>(userTaskModelView);

            if (!await _userTaskService.Insert(userTask))
                return BadRequest("Erro ao inserir tarefa!");

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetUserTask(int id)
        {
            var userTask = await _userTaskService.GetById(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return userTask;
        }

        [HttpGet]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetAllUserTasks()
        {
            return await _userTaskService.GetAll();
        }
    }
}
