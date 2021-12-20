using Reminder.Core;

namespace DatabaseFiller
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = @"Data Source=CMDB-80194;Initial Catalog=RemindersDb;Integrated Security=True";
            var taskToDoService = new TaskToDoService(connectionString);
            var filler = new Filler(taskToDoService, 15);

            filler.FillTableWithRandomValues(5, 9);
        }
    }
}