using System;
using Reminder.Core;
using Reminder.Entities;

namespace DatabaseFiller
{
    public class Filler
    {
        private readonly TaskToDoService _taskToDoService;
        private readonly int _entitiesCount;

        public Filler(TaskToDoService taskToDoService, int entitiesCount)
        {
            _taskToDoService = taskToDoService;
            _entitiesCount = entitiesCount;
        }

        public void FillTableWithRandomValues()
        {
            var randomizer = new StringRandomizer();

            for (int i = 0; i < _entitiesCount; i++)
            {
                var taskToDo = new TaskToDo
                {
                    Title = randomizer.GetRandomString(5),
                    DeadlineTime = Convert.ToDateTime("03-03-2002"),
                    Description = randomizer.GetRandomString(9)
                };
                
                _taskToDoService.AddOrUpdateTask(taskToDo);
            }
        }
    }
}