using Reminder.Core;

namespace DatabaseFiller
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RemindersDb;Integrated Security=True";
            var filler = new Filler(new TaskToDoService(connectionString), 15);

            filler.FillTableWithRandomValues();
        }
    }
}