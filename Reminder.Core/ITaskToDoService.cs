using System.ComponentModel;
using Reminder.Entities;

namespace Reminder.Core
{
    public interface ITaskToDoService
    {
        BindingList<TaskToDo> GetAllTasks();
        void AddTask(TaskToDo task);
        void UpdateTask(TaskToDo task);
        void DeleteTask(int id);
    }
}