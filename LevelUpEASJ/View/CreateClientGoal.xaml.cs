using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using LevelUpEASJ.Persistency;
using LevelUpEASJ.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LevelUpEASJ.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateClientGoal : Page
    {

        LevelUpViewModel luvm = new LevelUpViewModel();
        

        public CreateClientGoal()
        {
            this.InitializeComponent();
            this.DataContext = luvm;
        }
        //private const string apiId = "api/Exercis/";
        //private string serverUrl = "http://localhost:53409";
        //private Client _clients;
        //private List<Client> _clientlist;
        //private LevelUpCRUD<Client> _levelUpCrud;
        //private ObservableCollection<Client> _allClients;
        //private ClientCatalogSingleton clientCatalog;
        //private ObservableCollection<Exercise> _exercise;
        //private ExerciseCatalogSingleton _exerciseCatalogSingleton;

        //public CreateClientGoal(object user)
        //{
        //    _clientlist = new List<Client>();
        //    _levelUpCrud = new LevelUpCRUD<Client>(serverUrl, apiId);
        //    return;
        //}

        


        private void Create_Client_Goal_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainerClientView));
            
        }
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminLogin));

        }

        private void Hamburgerbutton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainerPage));
        }
        private void Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }


        




    }
}
