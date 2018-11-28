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
using ToDoList.Classes;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {

        private  String username;
        private  String password;
        private ToDoUser userObject = new ToDoUser();
        


        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(ToDoUser user )
        {

            InitializeComponent();

            this.userObject = user;
        
            this.username = this.userObject.getName();
            setUsername( this.username);
            generateAllTasks();
        }

        private void setUsername(String username)
        {
           this.usernameText.Text = username;
            this.usernameText.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void generateAllTasks()
        {

            List<TaskList> tl = userObject.getUserToDoList();
            if (tl.Count > 0)
            {
                List<Task> task = tl[0].getTaskListList();

                if (task != null)
                {
                    int size = task.Count();

                    if (size == 0)
                    {
                        this.TaskOne.Visibility = Visibility.Hidden;
                        this.TaskOneText.Visibility = Visibility.Hidden;
                        this.TaskTwo.Visibility = Visibility.Hidden;
                        this.TaskTwoText.Visibility = Visibility.Hidden;
                        this.TaskThree.Visibility = Visibility.Hidden;
                        this.TaskThreeText.Visibility = Visibility.Hidden;
                        this.TaskFour.Visibility = Visibility.Hidden;
                        this.TaskFourText.Visibility = Visibility.Hidden;

                    }
                    else if (size == 1)
                    {
                        this.TaskOne.Visibility = Visibility.Visible;
                        this.TaskOneText.Visibility = Visibility.Visible;
                        this.TaskOneText.Text = task[0].getTitle();

                        this.TaskTwo.Visibility = Visibility.Hidden;
                        this.TaskTwoText.Visibility = Visibility.Hidden;
                        this.TaskThree.Visibility = Visibility.Hidden;
                        this.TaskThreeText.Visibility = Visibility.Hidden;
                        this.TaskFour.Visibility = Visibility.Hidden;
                        this.TaskFourText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 2)
                    {
                        this.TaskOne.Visibility = Visibility.Visible;
                        this.TaskOneText.Visibility = Visibility.Visible;
                        this.TaskOneText.Text = task[0].getTitle();

                        this.TaskTwo.Visibility = Visibility.Visible;
                        this.TaskTwoText.Visibility = Visibility.Visible;
                        this.TaskTwoText.Text = task[1].getTitle();

                        this.TaskThree.Visibility = Visibility.Hidden;
                        this.TaskThreeText.Visibility = Visibility.Hidden;
                        this.TaskFour.Visibility = Visibility.Hidden;
                        this.TaskFourText.Visibility = Visibility.Hidden;

                    }
                    else if (size == 3)
                    {
                        this.TaskOne.Visibility = Visibility.Visible;
                        this.TaskOneText.Visibility = Visibility.Visible;
                        this.TaskOneText.Text = task[0].getTitle();

                        this.TaskTwo.Visibility = Visibility.Visible;
                        this.TaskTwoText.Visibility = Visibility.Visible;
                        this.TaskTwoText.Text = task[1].getTitle();

                        this.TaskThree.Visibility = Visibility.Visible;
                        this.TaskThreeText.Visibility = Visibility.Visible;
                        this.TaskThreeText.Text = task[2].getTitle();


                        this.TaskFour.Visibility = Visibility.Hidden;
                        this.TaskFourText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 4)
                    {
                        this.TaskOne.Visibility = Visibility.Visible;
                        this.TaskOneText.Visibility = Visibility.Visible;
                        this.TaskOneText.Text = task[0].getTitle();

                        this.TaskTwo.Visibility = Visibility.Visible;
                        this.TaskTwoText.Visibility = Visibility.Visible;
                        this.TaskTwoText.Text = task[1].getTitle();

                        this.TaskThree.Visibility = Visibility.Visible;
                        this.TaskThreeText.Visibility = Visibility.Visible;
                        this.TaskThreeText.Text = task[2].getTitle();


                        this.TaskFour.Visibility = Visibility.Visible;
                        this.TaskFourText.Visibility = Visibility.Visible;
                        this.TaskThreeText.Text = task[3].getTitle();
                    }
                }
               
            }
            

            //loop through tasks and display them on the dashboard
            //foreach(var task in )//in TaskList's List
            //{

            //}

        }


        private void createList(object sender, RoutedEventArgs e)
        {
            CreateList ct = new CreateList(userObject);
            NavigationService.Navigate(ct);

            //NavigationService nav = NavigationService.GetNavigationService(this);
           // nav.Navigate(new Uri("/GUI/CreateTask.xaml", UriKind.RelativeOrAbsolute));
        }

        private void taskClick1(object sender, RoutedEventArgs e)
        {
            int taskIndex = 0;
            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick2(object sender, RoutedEventArgs e)
        {
            int taskIndex = 1;
            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }
        private void taskClick3(object sender, RoutedEventArgs e)
        {
            int taskIndex = 2;
            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }
        private void taskClick4(object sender, RoutedEventArgs e)
        {
            int taskIndex = 3;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        /*
        private void sendToCompleteTask(int taskIndex)
        {
            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }*/


       
        //need: +add button always goes to bottom of display

        //need: when lists are added, add a new RowDefinition (increase grid.rowspan on navyBackground & whiteBackground)
    }
}
