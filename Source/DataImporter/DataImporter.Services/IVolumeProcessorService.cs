using System.Collections.Immutable;

namespace DataImporter.Services
{
    public interface IVolumeProcessorService
    {
        double GetVolume(ImmutableList<Grid2D> data);

        double GetVolumeAboveFluidContact(ImmutableList<Grid2D> data, double fluidContact);
    }
}