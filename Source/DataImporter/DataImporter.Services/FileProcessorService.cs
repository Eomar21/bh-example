using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Globalization;

namespace DataImporter.Services
{
    internal class FileProcessorService : IFileProcessorService
    {
        public ProcessedData ReadAndProcess(string path, double topToBaseDistance, double fluidContact, double crossInterval, double inlineInterval)
        {
            var list = ImmutableList<Grid2D>.Empty;
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
            };

            using var streamReader = File.OpenText(path);
            using var csvReader = new CsvReader(streamReader, csvConfig);

            string value;

            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    list = list.Add(new Grid2D(csvReader.Parser.Row - 1, csvReader.CurrentIndex, Convert.ToDouble(value), topToBaseDistance, fluidContact, crossInterval, inlineInterval));
                }
            }
            int crossCount = list.Where(x => x.CrossLineIndex == 0).Count();
            int inlineCount = list.Where(y => y.InlineIndex == 0).Count();
            return new ProcessedData(crossCount, inlineCount, list);
        }

        public void ExportFile(string path, ImmutableList<Grid2D> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, jsonData);
        }
    }
}
