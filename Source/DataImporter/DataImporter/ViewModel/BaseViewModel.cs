﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataImporter.ViewModel
{
    internal class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}