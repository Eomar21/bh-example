using DataImporter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Model
{
    internal class ImportFilePath
    {
        private readonly IGridFromDepthService gridFromDepthService;

        public ImportFilePath(IGridFromDepthService gridFromDepthService)
        {
            this.gridFromDepthService = gridFromDepthService;
        }

        public string ReadFile(string path)
        {
            Grid2D? t = gridFromDepthService.Create();
            return t.InlineCount.ToString();
        }
    }
}
