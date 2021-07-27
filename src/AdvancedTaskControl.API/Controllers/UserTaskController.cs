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
        private readonly IUserTaskSenderService _userTaskSenderService;

        private readonly IMapper _mapper;

        public UserTaskController(IUserTaskService userTaskService, 
                                  IUserTaskSenderService userTaskSenderService,
                                  IMapper mapper)
        {
            _userTaskService = userTaskService;            
            _userTaskSenderService = userTaskSenderService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult<UserTaskViewModel>> AddUserTask(UserTaskViewModel userTaskModelView)
        {
            var userTask = _mapper.Map<UserTask>(userTaskModelView);

            /*if (!await _userTaskService.Insert(userTask))
                return BadRequest("Erro ao inserir tarefa!");*/

            try
            { 
                await _userTaskService.Insert(userTask);                
            } 
            catch(Exception e)
            {
                return BadRequest("Erro ao inserir tarefa! Detalhes:  " + e.Message);
            }

            return Ok();
        }


        [HttpPost]
        [Route("api/[controller]/usertasks")]
        [Authorize(Roles = "ADM")]
        public ActionResult AddUserTasks(List<UserTaskViewModel> userTasksModelView)
        {
            foreach (var userTaskModelView in userTasksModelView)
            {
                var userTask = _mapper.Map<UserTask>(userTaskModelView);
                _userTaskSenderService.SendMessage(userTask);
            }

            return Accepted();
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
        [Authorize(Roles = "ADM,USER")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetAllUserTasks()
        {
            return await _userTaskService.GetAll();
        }
    }
}
