using System;
using Reminder.Core;
using Xunit;

namespace UnitTests
{
    public class Tests
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RemindersDb;Integrated Security=True";
        private readonly TaskToDoService _taskToDoService = new TaskToDoService(ConnectionString);
        
        [Fact]
        public void Test1()
        {
            
        }
    }
}