using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Entities;

namespace Reminder.DAL
{
    public class TaskToDoDatabaseAccess : IDatabaseAccess<TaskToDo>
    {
        private readonly string _connectionString;
        public TaskToDoDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BindingList<TaskToDo> GetAllEntities()
        {
            var result = new BindingList<TaskToDo>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM TasksToDo", connection);

                SqlDataReader reader = command.ExecuteReader();
 
                while (reader.Read())
                {
                    var newTask = new TaskToDo
                    {
                        Id = int.Parse(reader.GetValue(0).ToString()),
                        Title = reader.GetValue(1).ToString(),
                        DeadlineTime = Convert.ToDateTime(reader.GetValue(2)),
                        Description = reader.GetValue(2).ToString()
                    };
                    result.Add(newTask);
                }
            }

            return result;
        }
    }
}
