﻿using System;
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
    public sealed partial class TrainerPage : Page
    {
        LevelUpViewModel luvm = new LevelUpViewModel();

        public TrainerPage()
        {
            this.InitializeComponent();
            this.DataContext = luvm;

        }

        private void Hamburgerbutton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;

        }

        private void TrainerClientView_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainerClientView));
        }

        
       


        private void LogOutAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminLogin));
        }
        private void GoToCreateTraining_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateClientGoal));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TrainerNameBox.Text = luvm.trainerSingleton.NyTrainer.FirstName + " " + luvm.trainerSingleton.NyTrainer.LastName;
            CountOfClientsBox.Text = luvm.clientSingleton.Clients.Count.ToString();
            //NavnBox.Text = luvm.clientSingleton.NyClient.FirstName.ToString() + " " + luvm.clientSingleton.NyClient.LastName;
            //WeightBox.Text = luvm.clientSingleton.NyClient.Weight.ToString() + "kg";
            //XPBox.Text = "XP: " + luvm.clientSingleton.NyClient.TotalXP.ToString();
            //LevelBox.Text = "Level " + luvm.ClientLevel.ToString();
            //XpToNextLevel.Text = luvm.ClientXPtoNextLevel.ToString();
            //BMIblock.Text = "BMI: " + luvm.BMI.ToString("0.##");

        }


        private void GoToLevelPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SeeLevelsTrainer));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListOfExercises));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainerGoalListView));
        }
    }
}
