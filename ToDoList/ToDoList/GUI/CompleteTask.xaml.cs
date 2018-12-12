
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
        private List<Task> tasks = new List<Task>();
        private Dictionary<int, SubTask> subtasks = new Dictionary<int, SubTask>();
        private List<SubTask> subs = new List<SubTask>();
        private int subCount;
        private bool repeating;


        public CompleteTask()
        {
            InitializeComponent();
        }

        public CompleteTask(ToDoUser user, int taskIndex)
        {
            InitializeComponent();

            userObject = user;
            this.taskIndex = taskIndex;

            fillTaskInfo();
            fillSubtasks();
        }

        private void fillTaskInfo()
        {
            this.tasks = userObject.getUserToDoList()[0].getTaskListList();


            this.TaskTitleText.Text = tasks[taskIndex].getTitle();
            this.TaskDescriptionText.Text = tasks[taskIndex].getDescription();

             this.repeating = tasks[taskIndex].getRepeatability();
            if (repeating == true)
            {
                this.RepeatingText.Text = "Yes";
            }
            else if (repeating == false)
            {
                this.RepeatingText.Text = "No";
            }
        }

        private void fillSubtasks()
        {
            subtasks = tasks[taskIndex].getSubTask();
            int dictSize = subtasks.Count();
            if (dictSize > 0)
            {
                

                foreach (KeyValuePair<int, SubTask> entry in subtasks)
                {
                    subs.Add(entry.Value);
                }

                this.subCount = subs.Count();

                if (subCount == 1)
                {
                    this.sub1.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1Desc.Visibility = Visibility.Visible;

                    
                    bool one = this.sub1.IsChecked.Value;
                    this.sub1.Content = subs[0].getTitle();
                    this.sub1Date.Text = subs[0].getDueDate().ToString("yyyy/MM/dd");
                    this.sub1Desc.Text = subs[0].getNotes();
                    if (subs[0].isComplete() == true)
                    {
                        this.sub1.IsChecked = true;
                    }
                    else if (subs[0].isComplete() == false)
                    {
                        this.sub1.IsChecked = false;
                    }


                    this.sub2.Visibility = Visibility.Hidden;
                    this.sub2Date.Visibility = Visibility.Hidden;
                    this.sub2Desc.Visibility = Visibility.Hidden;

                    this.sub3.Visibility = Visibility.Hidden;
                    this.sub3Date.Visibility = Visibility.Hidden;
                    this.sub3Desc.Visibility = Visibility.Hidden;

                }
                else if (subCount == 2)
                {
                    this.sub1.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1Desc.Visibility = Visibility.Visible;

                    bool one = this.sub1.IsChecked.Value;
                    this.sub1.Content = subs[0].getTitle();
                    this.sub1Date.Text = subs[0].getDueDate().ToString("yyyy/MM/dd");
                    this.sub1Desc.Text = subs[0].getNotes();
                    if (subs[0].isComplete() == true)
                    {
                        this.sub1.IsChecked = true;
                    }
                    else if (subs[0].isComplete() == false)
                    {
                        this.sub1.IsChecked = false;
                    }


                    this.sub2.Visibility = Visibility.Visible;
                    this.sub2Date.Visibility = Visibility.Visible;
                    this.sub2Desc.Visibility = Visibility.Visible;

                    bool two = this.sub2.IsChecked.Value;
                    this.sub2.Content = subs[1].getTitle();
                    this.sub2Date.Text = subs[1].getDueDate().ToString("yyyy/MM/dd");
                    this.sub2Desc.Text = subs[1].getNotes();
                    if (subs[1].isComplete() == true)
                    {
                        this.sub2.IsChecked = true;
                    }
                    else if (subs[1].isComplete() == false)
                    {
                        this.sub2.IsChecked = false;
                    }

                    this.sub3.Visibility = Visibility.Hidden;
                    this.sub3Date.Visibility = Visibility.Hidden;
                    this.sub3Desc.Visibility = Visibility.Hidden;

                }
                else if (subCount >= 3)
                {
                    this.sub1.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1Desc.Visibility = Visibility.Visible;

                    bool one = this.sub1.IsChecked.Value;
                    this.sub1.Content = subs[0].getTitle();
                    this.sub1Date.Text = subs[0].getDueDate().ToString("yyyy/MM/dd");
                    this.sub1Desc.Text = subs[0].getNotes();
                    if (subs[0].isComplete() == true)
                    {
                        this.sub1.IsChecked = true;
                    }
                    else if (subs[0].isComplete() == false)
                    {
                        this.sub1.IsChecked = false;
                    }

                    this.sub2.Visibility = Visibility.Visible;
                    this.sub2Date.Visibility = Visibility.Visible;
                    this.sub2Desc.Visibility = Visibility.Visible;

                    bool two = this.sub2.IsChecked.Value;
                    this.sub2.Content = subs[1].getTitle();
                    this.sub2Date.Text = subs[1].getDueDate().ToString("yyyy/MM/dd");
                    this.sub2Desc.Text = subs[1].getNotes();
                    if (subs[1].isComplete() == true)
                    {
                        this.sub2.IsChecked = true;
                    }
                    else if (subs[1].isComplete() == false)
                    {
                        this.sub2.IsChecked = false;
                    }

                    this.sub3.Visibility = Visibility.Visible;
                    this.sub3Date.Visibility = Visibility.Visible;
                    this.sub3Desc.Visibility = Visibility.Visible;

                    bool three = this.sub3.IsChecked.Value;
                    this.sub3.Content = subs[2].getTitle();
                    this.sub3Date.Text = subs[2].getDueDate().ToString("yyyy/MM/dd");
                    this.sub3Desc.Text = subs[2].getNotes();
                    if (subs[2].isComplete() == true)
                    {
                        this.sub3.IsChecked = true;
                    }
                    else if (subs[2].isComplete() == false)
                    {
                        this.sub3.IsChecked = false;
                    }
                }
            }
            else
            {
                if (dictSize == 0)
                {
                    this.sub1.Visibility = Visibility.Hidden;
                    this.sub1Date.Visibility = Visibility.Hidden;
                    this.sub1Desc.Visibility = Visibility.Hidden;

                    this.sub2.Visibility = Visibility.Hidden;
                    this.sub2Date.Visibility = Visibility.Hidden;
                    this.sub2Desc.Visibility = Visibility.Hidden;

                    this.sub3.Visibility = Visibility.Hidden;
                    this.sub3Date.Visibility = Visibility.Hidden;
                    this.sub3Desc.Visibility = Visibility.Hidden;
                }
            }
            
            
        }

        private void sub1Check(object sender, RoutedEventArgs e)
        {
            
            

            subs[0].setComplete(true);
        }
        private void sub1uncheck(object sender, RoutedEventArgs e)
        {
            


            subs[0].setComplete(false);
        }

        private void sub2Check(object sender, RoutedEventArgs e)
        {
            


            subs[1].setComplete(true);
        }
        private void sub2uncheck(object sender, RoutedEventArgs e)
        {
            


            subs[1].setComplete(false);
        }

        private void sub3Check(object sender, RoutedEventArgs e)
        {
            


            subs[2].setComplete(true);
        }
        private void sub3uncheck(object sender, RoutedEventArgs e)
        {
           


            subs[2].setComplete(false);
        }

        private void completeAll(object sender, RoutedEventArgs e)
        {
            if (areAllChecked())
            {
                if (repeating)
                {
                    tasks[taskIndex].setIsComplete(true);
                    if( subCount >= 1)
                    {
                        subs[0].setComplete(false);
                    }
                    if (subCount >= 2)
                    {
                        subs[1].setComplete(false);
                    }
                    if (subCount >= 3)
                    {
                        subs[2].setComplete(false);
                    }
                }
                else
                {
                    tasks.Remove(tasks[taskIndex]);
                }

                Dashboard dash = new Dashboard(userObject);
                NavigationService.Navigate(dash);
            }



        }

        private bool areAllChecked()
        {
            if (this.subCount == 1)
            {
                if (this.sub1.IsChecked == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (this.subCount == 2)
            {
                if ((this.sub1.IsChecked == true) && (this.sub2.IsChecked == true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (this.subCount >= 3)
            {
                if ((this.sub1.IsChecked == true) && (this.sub2.IsChecked == true) && (this.sub3.IsChecked == true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            EditTask et = new EditTask(userObject, taskIndex, tasks, subtasks);
            NavigationService.Navigate(et);

            // NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("/GUI/EditTask.xaml", UriKind.RelativeOrAbsolute));
        }

        private void backToDash(object sender, RoutedEventArgs e)
        {
            // call needs to add something to check for completion of all tasks
            // that would require seven days being added to all the timelines for repeatable tasks


            Dashboard dash = new Dashboard(userObject);
            NavigationService.Navigate(dash);

            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("/GUI/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
