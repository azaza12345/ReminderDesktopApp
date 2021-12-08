using System.ComponentModel;
using System.Configuration;
using System.Windows;
using Reminder.Core;
using Reminder.Entities;

namespace ReminderDesktopApp
{
    public partial class MainWindow : Window
    {
        private readonly TaskToDoService _taskToDoService;
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

            DataGridReminders.ItemsSource = _tasks;
            _tasks.ListChanged += OnListChanged;
        }

        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted)
            {
                
            }
        }
    }
}
