namespace DataImporter.Services
{
    internal class GridFromDepthService : IGridFromDepthService
    {

        public GridFromDepthService()
        {
        }
        public Grid2D Create()
        {
            return new Grid2D(5, 5, 56);
        }
    }
}
