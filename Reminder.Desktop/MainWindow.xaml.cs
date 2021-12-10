using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using Reminder.Core;
using Reminder.Entities;

namespace Reminder.Desktop
{
    public partial class MainWindow : Window
    {
        private readonly ITaskToDoService _taskToDoService;
        private BindingList<TaskToDo> _tasks;
        public MainWindow()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;;
            _taskToDoService = new TaskToDoService(connectionString);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _tasks = _taskToDoService.GetAllTasks();
            DataGridTasks.ItemsSource = _tasks;
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            var task = CastToTask(e);
            _tasks.Remove(task);
            
            var id = task.Id;
            _taskToDoService.DeleteTask(id);
        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            var task = CastToTask(e);
            _taskToDoService.AddOrUpdateTask(task);
        }

        private TaskToDo CastToTask(RoutedEventArgs argument)
        {
            try
            {
                var task = (TaskToDo)((Button) argument.Source).DataContext;
                return task;
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show("Cast exception!");
            }

            return null;
        }
    }
}
