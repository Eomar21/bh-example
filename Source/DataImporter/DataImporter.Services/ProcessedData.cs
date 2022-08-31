using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    public class ProcessedData
    {
        public ImmutableList<Grid2D> Data { get; }
        public int CrossLineCount { get; }
        public int InLineCount { get; }
        public ProcessedData(int inLineCount, int crossLineCount, ImmutableList<Grid2D> data)
        {
            InLineCount = inLineCount;
            CrossLineCount = crossLineCount;
            Data = data;
        }
    }
}
