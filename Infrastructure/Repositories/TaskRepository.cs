using Application.Dtos;
using Application.Repositories;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetTaskDto>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks.Select(taskModel =>
                new GetTaskDto
                {
                    Id = taskModel.Id,
                    Title = taskModel.Title,
                    Description = taskModel.Description,
                    Status = taskModel.Status,
                }).ToList();
        }

        public async Task<GetTaskDto> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
                return new GetTaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                };
            else
                throw new KeyNotFoundException();
        }

        public async Task<int> AddTask(CreateTaskDto task)
        {
            var taskModel = new TaskModel
            {
                Title = task.Title,
                Description = task.Description,
            }; 

            _context.Tasks.Add(taskModel);
            await _context.SaveChangesAsync();
            return taskModel.Id;
        }

        public async Task UpdateTask(int id, UpdateTaskDto task)
        {
            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel != null)
            {
                taskModel.Title = task.Title;
                taskModel.Description = task.Description;
                await _context.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException();
        }

        public async Task ChangeStatusTask(int id, Domain.Enums.TaskStatusEnum taskStatus)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.Status = taskStatus;
                await _context.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException();
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException();
        }
    }
}
