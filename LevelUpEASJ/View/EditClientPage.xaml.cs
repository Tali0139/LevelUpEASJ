using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class EditClientPage : Page
    {
        LevelUpViewModel luvm = new LevelUpViewModel();

        public EditClientPage()
        {
            this.InitializeComponent();
            this.DataContext = luvm;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            NameOfUser_Box.Text = luvm.clientSingleton.NyClient.FirstName.ToString() + " " +
                           luvm.clientSingleton.NyClient.LastName;


        }

        

        private void Create_Client_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClientPage));
        }

        private void Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClientPage));
        }

        private void MinSide_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClientPage));
        }

        private void GoToUserLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

        private void Hamburgerbutton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;

        }

    }
}