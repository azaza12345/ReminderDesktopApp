using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using Reminder.Core;
using Reminder.Entities;

namespace ReminderDesktopApp
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
            // _taskToDoService.AddTask(new TaskToDo { Title = "Lol", DeadlineTime = DateTime.Now, Description = "Lol"});
            // _taskToDoService.AddTask(new TaskToDo { Title = "Kek", DeadlineTime = DateTime.Now, Description = "Kek"});
            // _taskToDoService.AddTask(new TaskToDo { Title = "Kek2", DeadlineTime = DateTime.Now, Description = "Kek3"});
            // _taskToDoService.AddTask(new TaskToDo { Title = "Kzaza", DeadlineTime = DateTime.Now, Description = "Kek4"});

            DataGridTasks.ItemsSource = _tasks;
            _tasks.ListChanged += OnListChanged;
        }

        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                // var itemId = _tasks[e.NewIndex].Id;
                // _taskToDoService.DeleteTask(itemId);
            }
            // if(e.ListChangedType == ListChangedType.ItemChanged ||
            //     e.ListChangedType == ListChangedType.ItemAdded ||
            //     e.ListChangedType == ListChangedType.ItemDeleted)
            // {
            //     
            // }
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            var task = (TaskToDo)((Button) e.Source).DataContext;
            _tasks.Remove(task);
            
            var id = task.Id;
            _taskToDoService.DeleteTask(id);
            //_taskToDoService.UpdateTask(task); 
        }
    }
}
