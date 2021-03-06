﻿using System;
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
        private List<Task> list = new List<Task>();

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
                if (this.dueDatePicker.SelectedDate == null)
                {
                    dueDate = new DateTime();
                }
                else
                {
                    dueDate = this.dueDatePicker.SelectedDate.Value.Date;
                }
               


                SubTask subt = new SubTask(dueDate, subTitle, subNotes);
                subt.SaveSubTask(); //save subtask to db
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
                rt.setTaskFKey(user.UserId);
                rt.SaveTask(); //save task to db
                list.Add(rt);

                Dashboard dash = new Dashboard(user);
                NavigationService.Navigate(dash);



            }
            else if (this.noRadio.IsChecked == true)
            {
                repeatable = false;
                //create disposableTask

                DisposableTask dt = new DisposableTask(taskTitle, taskDesc, dict);
                dt.setTaskFKey(user.UserId);
                //dt.setTaskFKey(55);
                //TODO user.UserId does not return the correct ID
                dt.SaveTask(); //save task to db
                list.Add(dt);

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
