namespace DataImporter.Model
{
    internal class InputsDepthModel : BaseObserver
    {
        private string m_ImportFilePath = "Select the file to import...";
        private double m_CellSizeEasting;
        private double m_CellSizeNorthing;
        private double m_BaseToTopDistance;
        private double m_FluidContact;

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

        public double BaseToTopDistance
        {
            get => m_BaseToTopDistance;
            set
            {
                m_BaseToTopDistance = value;
                NotifyPropertyChanged();
            }
        }

        public double FluidContact
        {
            get => m_FluidContact;
            set
            {
                m_FluidContact = value;
                NotifyPropertyChanged();
            }
        }
    }
}