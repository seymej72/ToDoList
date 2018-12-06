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

                        this.TaskFive.Visibility = Visibility.Hidden;
                        this.TaskFiveText.Visibility = Visibility.Hidden;

                        this.TaskSix.Visibility = Visibility.Hidden;
                        this.TaskSixText.Visibility = Visibility.Hidden;

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;

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

                        this.TaskFive.Visibility = Visibility.Hidden;
                        this.TaskFiveText.Visibility = Visibility.Hidden;

                        this.TaskSix.Visibility = Visibility.Hidden;
                        this.TaskSixText.Visibility = Visibility.Hidden;

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
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

                        this.TaskFive.Visibility = Visibility.Hidden;
                        this.TaskFiveText.Visibility = Visibility.Hidden;

                        this.TaskSix.Visibility = Visibility.Hidden;
                        this.TaskSixText.Visibility = Visibility.Hidden;

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;

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

                        this.TaskFive.Visibility = Visibility.Hidden;
                        this.TaskFiveText.Visibility = Visibility.Hidden;

                        this.TaskSix.Visibility = Visibility.Hidden;
                        this.TaskSixText.Visibility = Visibility.Hidden;

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Hidden;
                        this.TaskFiveText.Visibility = Visibility.Hidden;

                        this.TaskSix.Visibility = Visibility.Hidden;
                        this.TaskSixText.Visibility = Visibility.Hidden;

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 5)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();
                        

                        this.TaskSix.Visibility = Visibility.Hidden;
                        this.TaskSixText.Visibility = Visibility.Hidden;

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;

                    }
                    else if (size == 6)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                       

                        this.TaskSeven.Visibility = Visibility.Hidden;
                        this.TaskSevenText.Visibility = Visibility.Hidden;

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 7)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                       

                        this.TaskEight.Visibility = Visibility.Hidden;
                        this.TaskEightText.Visibility = Visibility.Hidden;

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 8)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                       

                        this.TaskNine.Visibility = Visibility.Hidden;
                        this.TaskNineText.Visibility = Visibility.Hidden;

                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 9)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        
                        this.TaskTen.Visibility = Visibility.Hidden;
                        this.TaskTenText.Visibility = Visibility.Hidden;

                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 10)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        
                        this.TaskEleven.Visibility = Visibility.Hidden;
                        this.TaskElevenText.Visibility = Visibility.Hidden;

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 11)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        this.TaskEleven.Visibility = Visibility.Visible;
                        this.TaskElevenText.Visibility = Visibility.Visible;
                        this.TaskElevenText.Text = task[10].getTitle();

                       

                        this.TaskTwelve.Visibility = Visibility.Hidden;
                        this.TaskTwelveText.Visibility = Visibility.Hidden;

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 12)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        this.TaskEleven.Visibility = Visibility.Visible;
                        this.TaskElevenText.Visibility = Visibility.Visible;
                        this.TaskElevenText.Text = task[10].getTitle();

                        this.TaskTwelve.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Text = task[11].getTitle();

                       

                        this.TaskThirteen.Visibility = Visibility.Hidden;
                        this.TaskThirteenText.Visibility = Visibility.Hidden;

                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 13)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        this.TaskEleven.Visibility = Visibility.Visible;
                        this.TaskElevenText.Visibility = Visibility.Visible;
                        this.TaskElevenText.Text = task[10].getTitle();

                        this.TaskTwelve.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Text = task[11].getTitle();

                        this.TaskThirteen.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Text = task[12].getTitle();

                        
                        this.TaskFourteen.Visibility = Visibility.Hidden;
                        this.TaskFourteenText.Visibility = Visibility.Hidden;

                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 14)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        this.TaskEleven.Visibility = Visibility.Visible;
                        this.TaskElevenText.Visibility = Visibility.Visible;
                        this.TaskElevenText.Text = task[10].getTitle();

                        this.TaskTwelve.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Text = task[11].getTitle();

                        this.TaskThirteen.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Text = task[12].getTitle();

                        this.TaskFourteen.Visibility = Visibility.Visible;
                        this.TaskFourteenText.Visibility = Visibility.Visible;
                        this.TaskFourteenText.Text = task[13].getTitle();


                        this.TaskFifteen.Visibility = Visibility.Hidden;
                        this.TaskFifteenText.Visibility = Visibility.Hidden;
                    }
                    else if (size == 15)
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        this.TaskEleven.Visibility = Visibility.Visible;
                        this.TaskElevenText.Visibility = Visibility.Visible;
                        this.TaskElevenText.Text = task[10].getTitle();

                        this.TaskTwelve.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Text = task[11].getTitle();

                        this.TaskThirteen.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Text = task[12].getTitle();

                        this.TaskFourteen.Visibility = Visibility.Visible;
                        this.TaskFourteenText.Visibility = Visibility.Visible;
                        this.TaskFourteenText.Text = task[13].getTitle();

                        this.TaskFifteen.Visibility = Visibility.Visible;
                        this.TaskFifteenText.Visibility = Visibility.Visible;
                        this.TaskFifteenText.Text = task[14].getTitle();
                    }
                    else
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
                        this.TaskFourText.Text = task[3].getTitle();

                        this.TaskFive.Visibility = Visibility.Visible;
                        this.TaskFiveText.Visibility = Visibility.Visible;
                        this.TaskFiveText.Text = task[4].getTitle();

                        this.TaskSix.Visibility = Visibility.Visible;
                        this.TaskSixText.Visibility = Visibility.Visible;
                        this.TaskSixText.Text = task[5].getTitle();

                        this.TaskSeven.Visibility = Visibility.Visible;
                        this.TaskSevenText.Visibility = Visibility.Visible;
                        this.TaskSevenText.Text = task[6].getTitle();

                        this.TaskEight.Visibility = Visibility.Visible;
                        this.TaskEightText.Visibility = Visibility.Visible;
                        this.TaskEightText.Text = task[7].getTitle();

                        this.TaskNine.Visibility = Visibility.Visible;
                        this.TaskNineText.Visibility = Visibility.Visible;
                        this.TaskNineText.Text = task[8].getTitle();

                        this.TaskTen.Visibility = Visibility.Visible;
                        this.TaskTenText.Visibility = Visibility.Visible;
                        this.TaskTenText.Text = task[9].getTitle();

                        this.TaskEleven.Visibility = Visibility.Visible;
                        this.TaskElevenText.Visibility = Visibility.Visible;
                        this.TaskElevenText.Text = task[10].getTitle();

                        this.TaskTwelve.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Visibility = Visibility.Visible;
                        this.TaskTwelveText.Text = task[11].getTitle();

                        this.TaskThirteen.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Visibility = Visibility.Visible;
                        this.TaskThirteenText.Text = task[12].getTitle();

                        this.TaskFourteen.Visibility = Visibility.Visible;
                        this.TaskFourteenText.Visibility = Visibility.Visible;
                        this.TaskFourteenText.Text = task[13].getTitle();

                        this.TaskFifteen.Visibility = Visibility.Visible;
                        this.TaskFifteenText.Visibility = Visibility.Visible;
                        this.TaskFifteenText.Text = task[14].getTitle();

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

        private void taskClick5(object sender, RoutedEventArgs e)
        {
            int taskIndex = 4;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick6(object sender, RoutedEventArgs e)
        {
            int taskIndex = 5;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick7(object sender, RoutedEventArgs e)
        {
            int taskIndex = 6;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick8(object sender, RoutedEventArgs e)
        {
            int taskIndex = 7;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick9(object sender, RoutedEventArgs e)
        {
            int taskIndex = 8;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }
        private void taskClick10(object sender, RoutedEventArgs e)
        {
            int taskIndex = 9;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }
        private void taskClick11(object sender, RoutedEventArgs e)
        {
            int taskIndex = 10;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }
        private void taskClick12(object sender, RoutedEventArgs e)
        {
            int taskIndex = 11;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }
        private void taskClick13(object sender, RoutedEventArgs e)
        {
            int taskIndex = 12;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick14(object sender, RoutedEventArgs e)
        {
            int taskIndex = 13;

            CompleteTask comp = new CompleteTask(userObject, taskIndex);
            NavigationService.Navigate(comp);
        }

        private void taskClick15(object sender, RoutedEventArgs e)
        {
            int taskIndex = 14;

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
