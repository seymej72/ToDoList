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
    /// Interaction logic for CreateList.xaml
    /// </summary>
    public partial class CreateList : Page
    {


        private string taskTitle;
        private string taskDesc;
        private Boolean repeatable;

        private string subTitle;
        private string subNotes;
        private DateTime dueDate;

        private Dictionary<int, SubTask> dict;

        private List<TaskList> tl;

        public CreateList()
        {
            InitializeComponent();
        }
        public CreateList( List<TaskList> tl)
        {
            InitializeComponent();

            this.tl = tl;

        }
        //notes field->somehow wrap text onto new line to fill box area? (it's all just going onto one line)
        private void addSubTask(object sender, RoutedEventArgs e)
        {

            if (subTitle == "" && subNotes == "")
            {
                
            }
            else
            {
                subTitle = this.subTitleText.Text;
                subNotes = this.subNotesText.Text;
                dueDate = this.dueDatePicker.SelectedDate.Value.Date;


                SubTask subt = new SubTask(dueDate, subTitle, subNotes);
                int nextId = subt.getNextId();
                subt.setId(nextId);

                dict.Add(nextId, subt);

                this.subTitleText.Text = "";
                this.subNotesText.Text = "";
                this.dueDatePicker.SelectedDate = null;
                this.dueDatePicker.DisplayDate = DateTime.Today;
            }
            
           
            
        }

        //if createTask is clicked
        private void backToDash(object sender, RoutedEventArgs e)
        {


            String taskTitle = this.taskTitleText.Text;
            String taskDesc = this.descText.Text;

            if (this.yesRadio.IsChecked == true)
            {
                repeatable = true;
                //create repeatableTask

                RepeatableTask rt = new RepeatableTask(taskTitle, taskDesc, dict);
                tl[0].addTask(rt);

                //todo: for sara: just pass THE USER OBJECT to EVERY PAGE


            }
            else if (this.noRadio.IsChecked == true)
            {
                repeatable = false;
                //create disposableTask

                DisposableTask dt = new DisposableTask(taskTitle, taskDesc, dict);
                tl[0].addTask(dt);

                

            }

            


            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
