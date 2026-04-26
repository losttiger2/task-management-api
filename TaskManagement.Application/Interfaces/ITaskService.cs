using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById(int id);
        Task CreateTask(TaskItem task);
        Task UpdateTask(TaskItem task);
        Task DeleteTask(int id);
    }
}
