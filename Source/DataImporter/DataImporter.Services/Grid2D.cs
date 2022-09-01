namespace DataImporter.Services
{
    public class Grid2D
    {
        public int InlineIndex { get; }
        public int CrossLineIndex { get; }
        public double CrossLineInterval { get; }
        public double InLineInterval { get; }
        public double Depth { get; }
        public double Easting { get; }
        public double Northing { get; }
        public double BaseHorizon { get; }
        public double FluidContact { get; }
        public double Volume => GetVolume();

        public Grid2D(int crossLineIndex, int inlineIndex, double depth, double baseToTopDistance, double fluidContact, double crossLineInterval, double inLineInterval)
        {
            CrossLineIndex = crossLineIndex;
            CrossLineInterval = crossLineInterval;
            InLineInterval = inLineInterval;
            InlineIndex = inlineIndex;
            Depth = depth; //Top horizon
            BaseHorizon = depth - baseToTopDistance;
            Northing = 0;
            Easting = 0;
            FluidContact = fluidContact;
        }

        public double GetVolume()
        {
            return CrossLineInterval * InLineInterval * (Depth - BaseHorizon);
        }
    }
}