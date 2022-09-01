using DataImporter.Helpers;
using DataImporter.Model;
using DataImporter.Services;
using System.Windows.Input;

namespace DataImporter.ViewModel
{
    internal class DataImporterViewModel : BaseViewModel
    {
        private readonly ICommand? m_ImportFileCommand;
        private readonly IVolumeProcessorService m_VolumeProcessorService;
        public readonly IFileProcessorService m_FileProcessorService;

        private InputsDepthModel m_InputsDepthModel;
        private OutputDepthModel m_OutputDepthModel;
        private readonly ICommand m_ExportFileCommand;
        private ProcessedData m_ProcessedData;

        public ICommand ExportFileCommand
        {
            get
            {
                if (m_ExportFileCommand == null)
                {
                    return new RelayCommand(p => Export());
                }
                return m_ExportFileCommand;
            }
        }

        public ICommand? ImportFileCommand
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

        public InputsDepthModel InputsDepthModel { get => m_InputsDepthModel; set => m_InputsDepthModel = value; }
        public OutputDepthModel OutputDepthModel { get => m_OutputDepthModel; set => m_OutputDepthModel = value; }

        public DataImporterViewModel(IVolumeProcessorService volumeProcessorService, IFileProcessorService fileProcessorService)
        {
            m_VolumeProcessorService = volumeProcessorService;
            m_FileProcessorService = fileProcessorService;
            m_InputsDepthModel = new();
            m_InputsDepthModel.CellSizeNorthing = 200;
            m_InputsDepthModel.CellSizeEasting = 200;
            m_InputsDepthModel.FluidContact = 9842.52; // 3000 meter
            m_InputsDepthModel.BaseToTopDistance = 328.084; // 100 meter
            m_OutputDepthModel = new();
        }

        private void Export()
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".json"; // Default file extension
            dialog.Filter = "Json File (.json)|*.json"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;
                m_FileProcessorService.ExportFile(filename, m_ProcessedData.Data);
            }
        }

        private void Import()
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "CSV UTF-8(Comma delimited)(*.csv)|*.csv;"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                m_InputsDepthModel.ImportFilePath = dialog.FileName;
                m_ProcessedData = m_FileProcessorService.ReadAndProcess(m_InputsDepthModel.ImportFilePath, m_InputsDepthModel.BaseToTopDistance, m_InputsDepthModel.FluidContact, m_InputsDepthModel.CellSizeEasting, m_InputsDepthModel.CellSizeNorthing);
                m_OutputDepthModel.InlineNodeCount = m_ProcessedData.InLineCount;
                m_OutputDepthModel.CrossLineNodeCount = m_ProcessedData.CrossLineCount;
                m_OutputDepthModel.Volume = m_VolumeProcessorService.GetVolumeAboveFluidContact(m_ProcessedData.Data, m_InputsDepthModel.FluidContact);
            }
        }
    }
}