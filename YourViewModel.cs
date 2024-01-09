using System.Windows;
public class YourViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ObservableCollection<TodoTask> TodoList { get; set; }
    public ICommand EditTaskCommand { get; private set; }
    public ICommand NewTaskCommand { get; private set; }

    private TodoTask selectedTask;

    public TodoTask SelectedTask
    {
        get { return selectedTask; }
        set
        {
            if (selectedTask != value)
            {
                selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
    }

    public YourViewModel()
    {
        TodoList = new ObservableCollection<TodoTask>();
        EditTaskCommand = new RelayCommand(EditTask);
        NewTaskCommand = new RelayCommand(CreateNewTask);
    }

    private void EditTask(object parameter)
    {
        if (SelectedTask != null)
        {
            var editWindow = new TaskDialogWindow();
            editWindow.DataContext = SelectedTask.Clone(); // Тут нужно  клонирование для избежания изменений в оригинале
            var result = editWindow.ShowDialog();

            if (result == true)
            {
                // Тут обновляем TodoList и соответствующий объект TodoTask
                int index = TodoList.IndexOf(SelectedTask);
                TodoList[index] = (TodoTask)editWindow.DataContext;
                OnPropertyChanged(nameof(TodoList));
            }
        }
    }

    private void CreateNewTask(object parameter)
    {
        var newTaskWindow = new TaskDialogWindow();
        var result = newTaskWindow.ShowDialog();

        if (result == true)
        {
            TodoList.Add((TodoTask)newTaskWindow.DataContext);
            OnPropertyChanged(nameof(TodoList));
        }
    }
}
