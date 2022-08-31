using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    public class Grid2D
    {
        public int InlineIndex { get; }
        public int CrossLineIndex { get; }
        public double Depth { get; }
        public double Easting { get; }
        public double Northing { get; }
        public double BaseHorizon { get; }
        public double FluidContact { get; }


        public Grid2D(int crossLineIndex, int inlineIndex, double depth)
        {
            CrossLineIndex = crossLineIndex;
            InlineIndex = inlineIndex;
            Depth = depth; //Top horizon
            BaseHorizon = depth - 328.084; // 100 meter in feet;
            Northing = 0;
            Easting = 0;
            FluidContact = 9842.52; // 3000 meter, in feet
        }
    }
}
