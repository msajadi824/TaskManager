using Domain.Models;

namespace Application.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskModel>> GetTasksAsync();
        Task<TaskModel> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskModel task);
        Task UpdateTaskAsync(TaskModel task);
        Task DeleteTaskAsync(int id);
    }
}
