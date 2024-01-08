public class YourViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TodoTask> TodoList { get; set; }
    public ICommand EditTaskCommand { get; private set; }
    public ICommand NewTaskCommand { get; private set; }

    public YourViewModel()
    {
        TodoList = new ObservableCollection<TodoTask>();
        EditTaskCommand = new RelayCommand(EditTask);
        NewTaskCommand = new RelayCommand(CreateNewTask);
    }

    private void EditTask(object parameter)
    {
        // Implementation for editing a task
    }

    private void CreateNewTask(object parameter)
    {
        // Implementation for creating a new task
    }

    // INotifyPropertyChanged implementation...
}

