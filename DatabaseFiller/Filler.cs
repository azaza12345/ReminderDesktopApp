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

        public void FillTableWithRandomValues(int titleLength, int descriptionLength)
        {
            var randomizer = new StringRandomizer();

            for (int i = 0; i < _entitiesCount; i++)
            {
                var taskToDo = new TaskToDo
                {
                    Title = randomizer.GetRandomString(titleLength),
                    DeadlineTime = DateTime.Now,
                    Description = randomizer.GetRandomString(descriptionLength)
                };
                
                _taskToDoService.AddOrUpdateTask(taskToDo);
            }
        }
    }
}