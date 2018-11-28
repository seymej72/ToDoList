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
            subtasks = tasks[taskIndex].getSubTask();
            int dictSize = subtasks.Count();
            if (dictSize > 0)
            {
                List<SubTask> subs = new List<SubTask>();

                foreach (KeyValuePair<int, SubTask> entry in subtasks)
                {
                    subs.Add(entry.Value);
                }

                int subCount = subs.Count();

                if (subCount == 1)
                {
                    this.sub1Name.Visibility = Visibility.Visible;
                    this.sub1NameBox.Visibility = Visibility.Visible;
                    this.sub1Notes.Visibility = Visibility.Visible;
                    this.sub1NotesBox.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1DatePicker.Visibility = Visibility.Visible;

                    this.sub1NameBox.Text = 

                    this.sub2Name.Visibility = Visibility.Hidden;
                    this.sub2NameBox.Visibility = Visibility.Hidden;
                    this.sub2Notes.Visibility = Visibility.Hidden;
                    this.sub2NotesBox.Visibility = Visibility.Hidden;
                    this.sub2Date.Visibility = Visibility.Hidden;
                    this.sub2DatePicker.Visibility = Visibility.Hidden;

                    this.sub3Name.Visibility = Visibility.Hidden;
                    this.sub3NameBox.Visibility = Visibility.Hidden;
                    this.sub3Notes.Visibility = Visibility.Hidden;
                    this.sub3NotesBox.Visibility = Visibility.Hidden;
                    this.sub3Date.Visibility = Visibility.Hidden;
                    this.sub3DatePicker.Visibility = Visibility.Hidden;

                    

                    bool one = this.sub1.IsChecked.Value;
                    this.sub1Date.Text = subs[0].getDueDate().ToString("yyyy/MM/dd");
                    this.sub1Desc.Text = subs[0].getNotes();

                    

                }
                else if (subCount == 2)
                {
                    this.sub1Name.Visibility = Visibility.Visible;
                    this.sub1NameBox.Visibility = Visibility.Visible;
                    this.sub1Notes.Visibility = Visibility.Visible;
                    this.sub1NotesBox.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1DatePicker.Visibility = Visibility.Visible;

                    this.sub2Name.Visibility = Visibility.Visible;
                    this.sub2NameBox.Visibility = Visibility.Visible;
                    this.sub2Notes.Visibility = Visibility.Visible;
                    this.sub2NotesBox.Visibility = Visibility.Visible;
                    this.sub2Date.Visibility = Visibility.Visible;
                    this.sub2DatePicker.Visibility = Visibility.Visible;

                    this.sub3Name.Visibility = Visibility.Hidden;
                    this.sub3NameBox.Visibility = Visibility.Hidden;
                    this.sub3Notes.Visibility = Visibility.Hidden;
                    this.sub3NotesBox.Visibility = Visibility.Hidden;
                    this.sub3Date.Visibility = Visibility.Hidden;
                    this.sub3DatePicker.Visibility = Visibility.Hidden;


                }
                else if (subCount == 3)
                {
                    this.sub1Name.Visibility = Visibility.Visible;
                    this.sub1NameBox.Visibility = Visibility.Visible;
                    this.sub1Notes.Visibility = Visibility.Visible;
                    this.sub1NotesBox.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1DatePicker.Visibility = Visibility.Visible;

                    this.sub2Name.Visibility = Visibility.Visible;
                    this.sub2NameBox.Visibility = Visibility.Visible;
                    this.sub2Notes.Visibility = Visibility.Visible;
                    this.sub2NotesBox.Visibility = Visibility.Visible;
                    this.sub2Date.Visibility = Visibility.Visible;
                    this.sub2DatePicker.Visibility = Visibility.Visible;

                    this.sub3Name.Visibility = Visibility.Visible;
                    this.sub3NameBox.Visibility = Visibility.Visible;
                    this.sub3Notes.Visibility = Visibility.Visible;
                    this.sub3NotesBox.Visibility = Visibility.Visible;
                    this.sub3Date.Visibility = Visibility.Visible;
                    this.sub3DatePicker.Visibility = Visibility.Visible;

                }
            }
            else
            {
                if (dictSize == 0)
                {
                    this.sub1Name.Visibility = Visibility.Hidden;
                    this.sub1NameBox.Visibility = Visibility.Hidden;
                    this.sub1Notes.Visibility = Visibility.Hidden;
                    this.sub1NotesBox.Visibility = Visibility.Hidden;
                    this.sub1Date.Visibility = Visibility.Hidden;
                    this.sub1DatePicker.Visibility = Visibility.Hidden;

                    this.sub2Name.Visibility = Visibility.Hidden;
                    this.sub2NameBox.Visibility = Visibility.Hidden;
                    this.sub2Notes.Visibility = Visibility.Hidden;
                    this.sub2NotesBox.Visibility = Visibility.Hidden;
                    this.sub2Date.Visibility = Visibility.Hidden;
                    this.sub2DatePicker.Visibility = Visibility.Hidden;

                    this.sub3Name.Visibility = Visibility.Hidden;
                    this.sub3NameBox.Visibility = Visibility.Hidden;
                    this.sub3Notes.Visibility = Visibility.Hidden;
                    this.sub3NotesBox.Visibility = Visibility.Hidden;
                    this.sub3Date.Visibility = Visibility.Hidden;
                    this.sub3DatePicker.Visibility = Visibility.Hidden;

                }
            }
        }


        private void backToComplete(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/CompleteTask.xaml", UriKind.RelativeOrAbsolute));


        }
    }
}
