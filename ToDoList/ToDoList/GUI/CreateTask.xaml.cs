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

        public CreateList()
        {
            InitializeComponent();
        }

        //notes field->somehow wrap text onto new line to fill box area? (it's all just going onto one line)
        private void addSubTask(object sender, RoutedEventArgs e)
        {
            subTitle = this.subTitleText.Text;
            subNotes = this.subNotesText.Text;
            dueDate = this.dueDatePicker.SelectedDate.Value.Date;


            SubTask subt = new SubTask(dueDate, subTitle, subNotes);
            
           
            
        }

        //if createTask is clicked
        private void backToDash(object sender, RoutedEventArgs e)
        {


            taskTitle = this.taskTitleText.Text;
            taskDesc = this.descText.Text;

            if (this.yesRadio.IsChecked == true)
            {
                repeatable = true;
                //create repeatableTask

                RepeatableTask rt = new RepeatableTask();

            }
            else if (this.noRadio.IsChecked == true)
            {
                repeatable = false;
                //create disposableTask

                DisposableTask dt = new DisposableTask();

            }

            


            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
