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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Color colorMintGreen = (Color)ColorConverter.ConvertFromString("#FF30B994");
        public SolidColorBrush mintGreen = new SolidColorBrush(colorMintGreen);

        public static Color colorGrey = (Color)ColorConverter.ConvertFromString("#FF484F57");
        public SolidColorBrush grey = new SolidColorBrush(colorGrey);

        public static Color colorTextGrey = (Color)ColorConverter.ConvertFromString("#FF69726F");
        public SolidColorBrush textGrey = new SolidColorBrush(colorTextGrey);

        public string username;
        public string password;
        public string passCheck;

        public ToDo todo = new ToDo();



        public Login()
        {
            InitializeComponent();
        }
        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            //change top button styling
            signUpButton.Background = mintGreen;
            signUpText.Foreground = Brushes.White;

            logInButton.Background = grey;
            logInText.Foreground = textGrey;

            //change user/pass fields
            usernameTextBox.Text = "Create Username";
           // passwordTextBox.Text = "Create Password";
            passwordRetypeTextBox.Visibility = Visibility.Visible;

            //change submit button
            submitButtonText.Text = "Create User";
            Grid.SetRow(submitButton, 10);

        }
        private void LogInClick(object sender, RoutedEventArgs e)
        {
            //change top button styling
            logInButton.Background = mintGreen;
            logInText.Foreground = Brushes.White;

            signUpButton.Background = grey;
            signUpText.Foreground = textGrey;

            //change user/pass fields
            usernameTextBox.Text = "Enter Username";
            //passwordTextBox.Text = "Enter Password";
            passwordRetypeTextBox.Visibility = Visibility.Hidden;

            //change submit button
            submitButtonText.Text = "Log In";
            Grid.SetRow(submitButton, 8);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void submitButtonClick(object sender, RoutedEventArgs e)
        {

            string submitButtonText = this.submitButtonText.Text;

            if (submitButtonText == "Create User")
            //if creating user
            {
                username = this.usernameTextBox.Text;
                password = this.passwordTextBox.Password.ToString();
                passCheck = this.passwordRetypeTextBox.Password.ToString();

                if (password == passCheck)
                {
                    ToDoUser user =  todo.RegisterUser(username, password);
                    int userID = user.UserId;
                    List<TaskList> tl = user.LoadList(userID);

                    dashboard dash = new dashboard(tl);
                    NavigationService.Navigate(dash);
                }

            }
            else if(submitButtonText == "Log In")
            //if logging in
            {
                username = this.usernameTextBox.Text;
                password = this.passwordTextBox.Password.ToString();


                //todo.LoginUser();

            }
            

            
            //sends user to dashboard if login is valid
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
