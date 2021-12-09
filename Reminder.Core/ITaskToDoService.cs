using System.ComponentModel;
using Reminder.Entities;

namespace Reminder.Core
{
    public interface ITaskToDoService
    {
        BindingList<TaskToDo> GetAllTasks();
        void AddOrUpdateTask(TaskToDo task);
        void DeleteTask(int id);
    }
}