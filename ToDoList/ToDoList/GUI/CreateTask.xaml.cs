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


        private String taskTitle;
        private String taskDesc;
        private Boolean repeatable;

        private String subTitle;
        private String subNotes;
        private DateTime dueDate;

        private Dictionary<int, SubTask> dict = new Dictionary<int, SubTask>();

        private ToDoUser user = new ToDoUser();
        private List<TaskList> list = new List<TaskList>();

        private int idCount = 0;


        public CreateList()
        {
            InitializeComponent();
        }
        public CreateList(ToDoUser user)
        {
            InitializeComponent();

            this.user = user;
            this.list = this.user.getUserToDoList();

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

                this.idCount++;

                //int nextId = subt.getNextId();
                //subt.setId(nextId);

                dict.Add(idCount, subt);

                this.subTitleText.Text = "";
                this.subNotesText.Text = "";
                this.dueDatePicker.SelectedDate = null;
                this.dueDatePicker.DisplayDate = DateTime.Today;
            }



        }

        //if createTask is clicked
        private void backToDash(object sender, RoutedEventArgs e)
        {


            taskTitle = this.taskTitleText.Text;
            taskDesc = this.descText.Text;

            if (this.yesRadio.IsChecked == true)
            {
                this.repeatable = true;
                //create repeatableTask

                RepeatableTask rt = new RepeatableTask(taskTitle, taskDesc, dict);
                list[0].addTask(rt);

                Dashboard dash = new Dashboard(user);
                NavigationService.Navigate(dash);



            }
            else if (this.noRadio.IsChecked == true)
            {
                repeatable = false;
                //create disposableTask

                DisposableTask dt = new DisposableTask(taskTitle, taskDesc, dict);
                list[0].addTask(dt);

                Dashboard dash = new Dashboard(user);
                NavigationService.Navigate(dash);

            }




            //NavigationService nav = NavigationService.GetNavigationService(this);
            // nav.Navigate(new Uri("/GUI/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void backButton(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard(user);
            NavigationService.Navigate(dash);
        }
    }
}
