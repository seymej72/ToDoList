using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for EditTask.xaml
    /// </summary>
    public partial class EditTask : Page
    {

        private ToDoUser userObject = new ToDoUser();
        private List<Task> tasks = new List<Task>();
        private Dictionary<int, SubTask> subtasks = new Dictionary<int, SubTask>();
        private int taskIndex;

        public EditTask()
        {
            InitializeComponent();

        }

        public EditTask(ToDoUser userObject, int taskIndex, List<Task> tasks, Dictionary<int, SubTask> subtasks)
        {
            InitializeComponent();
            this.userObject = userObject;
            this.tasks = tasks;
            this.subtasks = subtasks;
            this.taskIndex = taskIndex;

            fillTaskInfo();

        }

        private void fillTaskInfo()
        {
            this.tasks = userObject.getUserToDoList()[0].getTaskListList();


            this.TitleTextBox.Text = tasks[taskIndex].getTitle();
            this.descTextBox.Text = tasks[taskIndex].getDescription();

            bool repeating = tasks[taskIndex].getRepeatability();
            if (repeating == true)
            {
                this.yesButton.IsChecked = true;
            }
            else if (repeating == false)
            {
                this.noButton.IsChecked = true;
            }
        }
        private void fillSubtaskInfo()
        {

        }


        private void backToComplete(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/CompleteTask.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
