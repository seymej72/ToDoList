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



        public Login()
        {
            InitializeComponent();
        }
        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            signUpButton.Background = mintGreen;
            signUpText.Foreground = Brushes.White;

            logInButton.Background = grey;
            logInText.Foreground = textGrey;

        }
        private void LogInClick(object sender, RoutedEventArgs e)
        {
            logInButton.Background = mintGreen;
            logInText.Foreground = Brushes.White;

            signUpButton.Background = grey;
            signUpText.Foreground = textGrey;

        }

    }
}
