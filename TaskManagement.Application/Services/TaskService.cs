using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public async Task CreateTask(TaskItem task)
        {
            await _taskRepository.Add(task);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task != null)
            {
                _taskRepository.Delete(task);
                await _taskRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            //throw new Exception("Test exception from service"); Test middleware by throwing an exception.
            return await _taskRepository.GetAllAsync(); 
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task UpdateTask(TaskItem task)
        {
            _taskRepository.Update(task);
            await _taskRepository.SaveChangesAsync();
        }
    }
}
