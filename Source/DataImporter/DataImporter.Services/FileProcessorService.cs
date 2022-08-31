using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    internal class FileProcessorService : IFileProcessorService
    {
        public ImmutableList<Grid2D> ReadAndProcess(string path)
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
                    list = list.Add(new Grid2D(csvReader.Parser.Row - 1, csvReader.CurrentIndex, Convert.ToDouble(value)));
                }
            }
            return list;
        }

        public void ExportFile(string path, ImmutableList<Grid2D> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, jsonData);
        }
    }
}
