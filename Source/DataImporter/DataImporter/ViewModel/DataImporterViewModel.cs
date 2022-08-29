﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.ViewModel
{
    public class DataImporterViewModel : INotifyPropertyChanged
    {
        private string m_ImportFilePath = "Select the file to import...";
        private double m_CellSizeEasting = 0;

        public string ImportFilePath
        {
            get => m_ImportFilePath;
            set
            {
                m_ImportFilePath = value;
                NotifyPropertyChanged();
            }
        }

        public double CellSizeEasting
        {
            get => m_CellSizeEasting;
            set
            {
                m_CellSizeEasting = value;
                NotifyPropertyChanged();
            }
        }
        public double CellSizeNorthing { get; set; } = 0;
        public int InlineNodeCount { get; set; } = 0;
        public int CrossLineNodeCount { get; set; } = 0;
        public DataImporterViewModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
