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
        private int subCount;
        private List<SubTask> subs = new List<SubTask>();

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
            fillSubtaskInfo();

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
                
                foreach (KeyValuePair<int, SubTask> entry in subtasks)
                {
                    subs.Add(entry.Value);
                }

                 subCount = subs.Count();

                if (subCount == 1)
                {
                    this.sub1Name.Visibility = Visibility.Visible;
                    this.sub1NameBox.Visibility = Visibility.Visible;
                    this.sub1Notes.Visibility = Visibility.Visible;
                    this.sub1NotesBox.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1DatePicker.Visibility = Visibility.Visible;

                    this.sub1NameBox.Text = subs[0].getTitle();
                    this.sub1NotesBox.Text = subs[0].getNotes();
                    this.sub1DatePicker.DisplayDate = subs[0].getDueDate();

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
                else if (subCount == 2)
                {
                    this.sub1Name.Visibility = Visibility.Visible;
                    this.sub1NameBox.Visibility = Visibility.Visible;
                    this.sub1Notes.Visibility = Visibility.Visible;
                    this.sub1NotesBox.Visibility = Visibility.Visible;
                    this.sub1Date.Visibility = Visibility.Visible;
                    this.sub1DatePicker.Visibility = Visibility.Visible;

                    this.sub1NameBox.Text = subs[0].getTitle();
                    this.sub1NotesBox.Text = subs[0].getNotes();
                    this.sub1DatePicker.DisplayDate = subs[0].getDueDate();

                    this.sub2Name.Visibility = Visibility.Visible;
                    this.sub2NameBox.Visibility = Visibility.Visible;
                    this.sub2Notes.Visibility = Visibility.Visible;
                    this.sub2NotesBox.Visibility = Visibility.Visible;
                    this.sub2Date.Visibility = Visibility.Visible;
                    this.sub2DatePicker.Visibility = Visibility.Visible;

                    this.sub2NameBox.Text = subs[1].getTitle();
                    this.sub2NotesBox.Text = subs[1].getNotes();
                    this.sub2DatePicker.DisplayDate = subs[1].getDueDate();


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

                    this.sub1NameBox.Text = subs[0].getTitle();
                    this.sub1NotesBox.Text = subs[0].getNotes();
                    this.sub1DatePicker.DisplayDate = subs[0].getDueDate();

                    this.sub2Name.Visibility = Visibility.Visible;
                    this.sub2NameBox.Visibility = Visibility.Visible;
                    this.sub2Notes.Visibility = Visibility.Visible;
                    this.sub2NotesBox.Visibility = Visibility.Visible;
                    this.sub2Date.Visibility = Visibility.Visible;
                    this.sub2DatePicker.Visibility = Visibility.Visible;

                    this.sub2NameBox.Text = subs[1].getTitle();
                    this.sub2NotesBox.Text = subs[1].getNotes();
                    this.sub2DatePicker.DisplayDate = subs[1].getDueDate();

                    this.sub3Name.Visibility = Visibility.Visible;
                    this.sub3NameBox.Visibility = Visibility.Visible;
                    this.sub3Notes.Visibility = Visibility.Visible;
                    this.sub3NotesBox.Visibility = Visibility.Visible;
                    this.sub3Date.Visibility = Visibility.Visible;
                    this.sub3DatePicker.Visibility = Visibility.Visible;

                    this.sub3NameBox.Text = subs[2].getTitle();
                    this.sub3NotesBox.Text = subs[2].getNotes();
                    this.sub3DatePicker.DisplayDate = subs[2].getDueDate();

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

        private void editTask(object sender, RoutedEventArgs e)
        {
            //task info
            tasks[taskIndex].setTitle(this.TitleTextBox.Text);
            tasks[taskIndex].setDescription(this.descTextBox.Text);

            bool yes = this.yesButton.IsChecked.Value;
            bool no = this.noButton.IsChecked.Value;

            bool repeating = tasks[taskIndex].getRepeatability();
            /*
             * TODO: if the repeatable value changes the disposable/repeatable task needs to be changed 
             */
            if (yes == true)
            {
                if (repeating != yes)
                {
                    userObject.getUserToDoList()[0].switchTaskType(taskIndex);
                }
            }
            else if (no == true)
            {
                if (repeating == no)
                {
                    userObject.getUserToDoList()[0].switchTaskType(taskIndex);
                }
            }

            //subtasks

            int index = 0;
            foreach (KeyValuePair<int, SubTask> entry in subtasks)
            {
                subs.Add(entry.Value);
                String title = "";
                String notes = "";

                DateTime date = new DateTime();


                /*
                 * TODO: if DateTime doesn't have a value it crashes :) 
                 */
                if (index == 0)
                {
                    title = this.sub1NameBox.Text;
                    notes = this.sub1NotesBox.Text;

                    if (this.sub1DatePicker.SelectedDate == null)
                    {
                        date = new DateTime();
                    }
                    else
                    {
                        date = this.sub1DatePicker.SelectedDate.Value.Date;
                    }
                }
                else if (index == 1)
                {
                    title = this.sub2NameBox.Text;
                    notes = this.sub2NotesBox.Text;
                    if (this.sub2DatePicker.SelectedDate == null)
                    {
                        date = new DateTime();
                    }
                    else
                    {
                        date = this.sub2DatePicker.SelectedDate.Value.Date;
                    }
                }
                else if (index == 2)
                {
                    title = this.sub3NameBox.Text;
                    notes = this.sub3NotesBox.Text;
                    if (this.sub3DatePicker.SelectedDate == null)
                    {
                        date = new DateTime();
                    }
                    else
                    {
                        date = this.sub3DatePicker.SelectedDate.Value.Date;
                    }
                }

                entry.Value.setTitle(title);
                entry.Value.setNotes(notes);

                
                if (date != new DateTime())
                {
                    entry.Value.setDueDate(date);
                }
                

                index++;
            }

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);

        }


        private void backToComplete(object sender, RoutedEventArgs e)
        {

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);


            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("/GUI/CompleteTask.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
