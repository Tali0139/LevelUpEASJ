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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LevelUpEASJ.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TrainerPage : Page
    {
        public TrainerPage()
        {
            this.InitializeComponent();
        }

        private void Hamburgerbutton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;

        }

        private void TrainerClientView_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainerClientView));
        }

        private void DailyCalenderTrainer_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DailyCalenderTrainer));
        }

        private void CalenderTrainer_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CalenderTrainer));
        }

        private void InventoryTrainerPage_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InventoryTrainerPage));
        }

        private void LogOutAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminLogin));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            //NavnBox.Text = luvm.clientSingleton.NyClient.FirstName.ToString() + " " + luvm.clientSingleton.NyClient.LastName;
            //WeightBox.Text = luvm.clientSingleton.NyClient.Weight.ToString() + "kg";
            //XPBox.Text = "XP: " + luvm.clientSingleton.NyClient.TotalXP.ToString();
            //LevelBox.Text = "Level " + luvm.ClientLevel.ToString();
            //XpToNextLevel.Text = luvm.ClientXPtoNextLevel.ToString();
            //BMIblock.Text = "BMI: " + luvm.BMI.ToString("0.##");

        }

    }
}
