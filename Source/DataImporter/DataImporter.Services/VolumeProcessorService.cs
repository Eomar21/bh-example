using System.Collections.Immutable;

namespace DataImporter.Services
{
    internal class VolumeProcessorService : IVolumeProcessorService
    {
        public double GetVolume(ImmutableList<Grid2D> data)
        {
            return data.Sum(x => x.Volume);
        }

        public double GetVolumeAboveFluidContact(ImmutableList<Grid2D> data, double fluidContact)
        {
            var t = data.Where(x => x.BaseHorizon >= fluidContact);
            double x = t.Sum(x => x.Volume);
            return x;
        }
    }
}