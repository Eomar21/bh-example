using DataImporter.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataImporter.ViewModel
{
    public class DataImporterViewModel : INotifyPropertyChanged
    {
        private string m_ImportFilePath = "Select the file to import...";
        private double m_CellSizeEasting = 0;
        private double m_CellSizeNorthing = 0;

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
        public double CellSizeNorthing
        {
            get => m_CellSizeNorthing;
            set
            {
                m_CellSizeNorthing = value;
                NotifyPropertyChanged();
            }
        }
        public int InlineNodeCount { get; set; } = 0;
        public int CrossLineNodeCount { get; set; } = 0;
        public ICommand ImportFileCommand
        {
            get
            {
                if (m_ImportFileCommand == null)
                {
                    return new RelayCommand(p => Import());
                }
                return m_ImportFileCommand;
            }
        }

        public DataImporterViewModel()
        {

        }

        private ICommand m_ImportFileCommand;

        private void Import()
        {
            MessageBox.Show($"it works {CellSizeEasting}");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
