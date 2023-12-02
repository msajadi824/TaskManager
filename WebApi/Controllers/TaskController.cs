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

        /// <summary>
        /// دریافت همه تسک ها
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GellAllTasks")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetTasks();
            return Ok(tasks);
        }

        /// <summary>
        /// جزئیات یک تسک
        /// </summary>
        /// <param name="id">آی دی تسک</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// افزودن تسک
        /// </summary>
        /// <param name="task">مشخصات تسک</param>
        /// <returns></returns>
        [HttpPost(Name = "AddTask")]
        public async Task<IActionResult> AddTask([FromBody] CreateTaskDto task)
        {
            int Id = await _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = Id }, task);
        }

        /// <summary>
        /// ویرایش یک تسک
        /// </summary>
        /// <param name="id">آی دی تسک</param>
        /// <param name="task">مشخصات جدید</param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "UpdateTask")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto task)
        {
            await _taskService.UpdateTask(id, task);
            return NoContent();
        }

        /// <summary>
        /// تغییر وضعیت تسک
        /// </summary>
        /// <param name="id">ای دی تسک</param>
        /// <param name="taskStatus">وضعیت جدید</param>
        /// <returns></returns>
        [HttpPatch("{id}/{taskStatus}", Name = "ChangeStatusTask")]
        public async Task<IActionResult> ChangeStatusTask(int id, Domain.Enums.TaskStatusEnum taskStatus)
        {
            await _taskService.ChangeStatusTask(id, taskStatus);
            return NoContent();
        }

        /// <summary>
        /// حذف یک تسک
        /// </summary>
        /// <param name="id">ای دی تسک</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
