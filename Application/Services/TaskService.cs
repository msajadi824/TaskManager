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

        public async Task<IEnumerable<TaskModel>> GetTasksAsync()
        {
            return await _taskRepository.GetTasksAsync();
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task AddTaskAsync(TaskModel task)
        {
            await _taskRepository.AddTaskAsync(task);
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }
    }
}
