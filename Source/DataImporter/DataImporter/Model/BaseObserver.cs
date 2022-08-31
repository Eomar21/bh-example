using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataImporter.Model
{
    internal class BaseObserver : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
