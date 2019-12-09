using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LevelUpEASJ.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LevelUpEASJ.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminLogin : Page
    {
        LevelUpViewModel luvm = new LevelUpViewModel();
        public AdminLogin()
        {
            this.InitializeComponent();
            this.DataContext = luvm;
        }

        private async void AdminLogin_Click (object sender, RoutedEventArgs e)
        {

           
                var messageDialogWrong = new MessageDialog("Brugernavn og/eller adgangskode ikke korrekt");
                var messageDialogEnter = new MessageDialog("Indtast brugernavn og adgangskode");
                string username = UsernameBox.Text;
                string password = PasswordBox.Password;
                bool afterCheck = luvm.DoesAdminExist(username, password);
                {
                    {
                        if (afterCheck == true)
                            this.Frame.Navigate(typeof(TrainerPage));
                        else if (UsernameBox.Text == "" && PasswordBox.Password == "")
                        {
                            await messageDialogEnter.ShowAsync();
                        }
                        else
                        {
                            await messageDialogWrong.ShowAsync();
                        }
                    }
                }
        }


        private void GoToUserLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

    }
}
