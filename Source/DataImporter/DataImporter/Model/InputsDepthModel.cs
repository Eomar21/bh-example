namespace DataImporter.Model
{
    internal class InputsDepthModel : BaseObserver
    {
        private string m_ImportFilePath = "Select the file to import...";
        private double m_CellSizeEasting;
        private double m_CellSizeNorthing;

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
    }
}
