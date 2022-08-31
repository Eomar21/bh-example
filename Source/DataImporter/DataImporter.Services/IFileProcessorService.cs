using System.Collections.Immutable;

namespace DataImporter.Services
{
    public interface IFileProcessorService
    {
        ProcessedData ReadAndProcess(string path);
        void ExportFile(string path, ImmutableList<Grid2D> data);

    }
}