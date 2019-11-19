﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Annotations;

namespace LevelUpEASJ.ViewModel
{
    class ClientViewModel : INotifyPropertyChanged
    {
        private IUser _ iUser;
        private Client _client;
        private ClientCatalogSingleton _ singleton;




























        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}