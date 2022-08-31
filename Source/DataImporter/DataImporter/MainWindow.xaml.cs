using DataImporter.Services;
using DataImporter.ViewModel;
using System.Windows;

namespace DataImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IGridFromDepthService m_SampleService;
        private readonly IFileProcessorService m_FileProcessorService;

        public MainWindow(IGridFromDepthService gridFromDepthService, IFileProcessorService fileProcessorService)
        {
            m_SampleService = gridFromDepthService;
            m_FileProcessorService = fileProcessorService;
            DataContext = new DataImporterViewModel(m_SampleService, m_FileProcessorService);
            InitializeComponent();
        }
    }
}
