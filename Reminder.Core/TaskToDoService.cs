using System.Collections.Generic;
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

        public void AddTask(TaskToDo task)
        {
            _databaseAccess.Add(task);
        }

        public void UpdateTask(TaskToDo task)
        {
            _databaseAccess.Update(task);
        }
        
        public void DeleteTask(int id)
        {
            _databaseAccess.Delete(id);
        }
    }
}