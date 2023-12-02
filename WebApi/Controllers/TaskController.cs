using Application.Dtos;
using Domain.Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTaskDto task)
        {
            int Id = await _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto task)
        {
            await _taskService.UpdateTask(id, task);
            return NoContent();
        }

        [HttpPatch("{id}/{taskStatus}")]
        public async Task<IActionResult> ChangeStatusTask(int id, Domain.Enums.TaskStatusEnum taskStatus)
        {
            await _taskService.ChangeStatusTask(id, taskStatus);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
