using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Common;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper) 
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasks();
            var result = _mapper.Map<IEnumerable<TaskDTO>>(tasks);
            return Ok(new ApiResponse<IEnumerable<TaskDTO>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _taskService.GetTaskById(id);

            if (task == null) { return NotFound(); }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDTO dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            await _taskService.CreateTask(task);
            return Ok(new ApiResponse<string>(null, "Task created successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskUpdateDTO dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            await _taskService.UpdateTask(task);
            return Ok(new ApiResponse<string>(null, "Task updated successfully"));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteTask(id);
            return Ok(new ApiResponse<string>(null, "Task deleted successfully"));
        }
    }
}
