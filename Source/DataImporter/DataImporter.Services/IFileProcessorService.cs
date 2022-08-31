using System.Collections.Immutable;

namespace DataImporter.Services
{
    public interface IFileProcessorService
    {
        ImmutableList<Grid2D> ReadAndProcess(string path);
        void ExportFile(string path, ImmutableList<Grid2D> data);

    }
}