﻿using AdvancedTaskControl.API.ViewModels;
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
        private readonly IUserTaskAllocatorService _userTaskAllocatorService;

        private readonly IMapper _mapper;

        public UserTaskController(IUserTaskService userTaskService, IUserTaskAllocatorService userTaskAllocatorService, IMapper mapper)
        {
            _userTaskService = userTaskService;
            _userTaskAllocatorService = userTaskAllocatorService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult<UserTaskViewModel>> AddUserTask(UserTaskViewModel userTaskModelView)
        {
            var userTask = _mapper.Map<UserTask>(userTaskModelView);

            userTask = _userTaskAllocatorService.AllocateUserTaskToUser(userTask);

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
        [Authorize(Roles = "ADM,USER")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetAllUserTasks()
        {
            return await _userTaskService.GetAll();
        }
    }
}
