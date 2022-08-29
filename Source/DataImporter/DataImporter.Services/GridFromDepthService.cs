using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    internal class GridFromDepthService : IGridFromDepthService
    {

        public GridFromDepthService()
        {
        }
        public Grid2D Create()
        {
            return new Grid2D(5, 5);
        }
    }
}
