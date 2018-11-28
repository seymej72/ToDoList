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
    /// Interaction logic for CompleteTask.xaml
    /// </summary>
    public partial class CompleteTask : Page
    {
        private ToDoUser userObject = new ToDoUser();
        private int taskIndex; 


        public CompleteTask()
        {
            InitializeComponent();
        }

        public CompleteTask(ToDoUser user, int taskIndex)
        {
            userObject = user;
            this.taskIndex = taskIndex;
        }

        private void fillTaskInfo()
        {
            List<Task> tasks = userObject.getUserToDoList()[0].getTaskListList();


            this.TaskTitleText.Text = tasks[taskIndex].getTitle();
            this.TaskDescriptionText.Text = tasks[taskIndex].getDescription();

            bool repeating = tasks[taskIndex].get
            if ()
            {

            }
        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/EditTask.xaml", UriKind.RelativeOrAbsolute));
        }

        private void backToDash(object sender, RoutedEventArgs e)
        {

            Dashboard dash = new Dashboard(userObject);
            NavigationService.Navigate(dash);

            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("/GUI/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
