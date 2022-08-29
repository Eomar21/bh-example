using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    public class Grid2D
    {
        public int InlineCount { get; }
        public int CrossLineCount { get; }

        public Grid2D(int crossLineCount, int inlineCount)
        {
            CrossLineCount = crossLineCount;
            InlineCount = inlineCount;
        }
    }
}
