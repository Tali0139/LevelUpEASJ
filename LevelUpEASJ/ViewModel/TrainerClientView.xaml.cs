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
    public sealed partial class TrainerClientView : Page
    {
        LevelUpViewModel luvm = new LevelUpViewModel();

        public TrainerClientView()
        {
            this.InitializeComponent();
            this.DataContext = luvm;

        }
        private void Hamburgerbutton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NameOfTrainer_Box.Text = luvm.trainerSingleton.NyTrainer.FirstName + " " + luvm.trainerSingleton.NyTrainer.LastName;
           

        }

        private void Trainer_Page_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainerPage));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminLogin));
        }
    }
}
