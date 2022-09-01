using System.Collections.Immutable;

namespace DataImporter.Services
{
    public interface IFileProcessorService
    {
        ProcessedData ReadAndProcess(string path, double topToBaseDistance, double fluidContact, double crossInterval, double inlineInterval);
        void ExportFile(string path, ImmutableList<Grid2D> data);

    }
}