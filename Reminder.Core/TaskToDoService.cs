using System.Collections.Generic;
using System.ComponentModel;
using Reminder.DAL;
using Reminder.Entities;

namespace Reminder.Core
{
    public class TaskToDoService
    {
        private readonly IDatabaseAccess<TaskToDo> _databaseAccess;
        public TaskToDoService(string connectionString)
        {
            _databaseAccess = new TaskToDoDatabaseAccess(connectionString);
        }

        public BindingList<TaskToDo> GetAllTasks()
        {
            var result = _databaseAccess.GetAllEntities();
            return result;
        }
    }
}