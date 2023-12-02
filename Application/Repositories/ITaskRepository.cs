using Application.Dtos;
using Domain.Enums;
using Domain.Models;

namespace Application.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<GetTaskDto>> GetTasks();
        Task<GetTaskDto> GetTaskById(int id);
        Task<int> AddTask(CreateTaskDto task);
        Task UpdateTask(int id, UpdateTaskDto task);
        Task ChangeStatusTask(int id, TaskStatusEnum taskStatus);
        Task DeleteTask(int id);
    }
}
