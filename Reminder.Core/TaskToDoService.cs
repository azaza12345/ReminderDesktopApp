using System.ComponentModel;
using Reminder.DAL;
using Reminder.Entities;

namespace Reminder.Core
{
    public class TaskToDoService : ITaskToDoService
    {
        private readonly IDatabaseAccess<TaskToDo> _databaseAccess;
        public TaskToDoService(string connectionString)
        {
            _databaseAccess = new TaskToDoDatabaseAccess(connectionString);
        }

        public BindingList<TaskToDo> GetAllTasks()
        {
            var result = _databaseAccess.GetAll();
            return result;
        }

        public void AddOrUpdateTask(TaskToDo task)
        {
            var gottenTask = _databaseAccess.GetById(task.Id);
            if (gottenTask.Id == 0)
            {
                _databaseAccess.Add(task);
            }
            else
            {
                _databaseAccess.Update(task);
            }
        }
        
        public void DeleteTask(int id)
        {
            _databaseAccess.Delete(id);
        }
    }
}