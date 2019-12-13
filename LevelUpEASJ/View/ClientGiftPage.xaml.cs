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
    public sealed partial class ClientGiftPage : Page
    {
        LevelUpViewModel luvm = new LevelUpViewModel();
        public ClientGiftPage()
        {
            this.InitializeComponent();
            this.DataContext = luvm;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NameOfUser_Box.Text = luvm.clientSingleton.NyClient.FirstName + " " + luvm.clientSingleton.NyClient.LastName;
            // billedbox.Source = luvm.clientSingleton.GetImageSource(luvm.clientSingleton.NyClient.Image);


        }

    }
}
