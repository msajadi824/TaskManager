using Application.Dtos;
using Application.Repositories;
using Domain.Models;

namespace Domain.Application
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<GetTaskDto>> GetTasks()
        {
            return await _taskRepository.GetTasks();
        }

        public async Task<GetTaskDto> GetTaskById(int id)
        {
            return await _taskRepository.GetTaskById(id);
        }

        public async Task<int> AddTask(CreateTaskDto task)
        {
            return await _taskRepository.AddTask(task);
        }

        public async Task UpdateTask(int id, UpdateTaskDto task)
        {
            await _taskRepository.UpdateTask(id, task);
        }

        public async Task ChangeStatusTask(int id, Enums.TaskStatusEnum taskStatus)
        {
            await _taskRepository.ChangeStatusTask(id, taskStatus);
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }
    }
}
