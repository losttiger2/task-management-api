using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(int id);
        Task Add(TaskItem item);
        void Update(TaskItem item);
        void Delete(TaskItem item);
        Task SaveChangesAsync();
    }
}
