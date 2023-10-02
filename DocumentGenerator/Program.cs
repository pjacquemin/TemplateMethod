using Classes;
using System.Collections.Generic;


namespace DocumentGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> data = GetDataFromDB();

            PDFGenerator pdfGenerator = new PDFGenerator(data);
            pdfGenerator.GenerateFiles();

            CsvGenerator csvGenerator = new CsvGenerator(data);
            csvGenerator.GenerateFiles();

            CsvGenerator csvGenerator2022 = new CsvGenerator2022(data);
            csvGenerator2022.GenerateFiles();
        }

        private static List<Data> GetDataFromDB()
        {
            List<Data> data = new List<Data>();

            data.Add(new Data
            {
                CustomerName = "Super solder",
                FirstQuarterVolume = 45,
                SecondQuarterVolume = 32,
                ThirdQuarterVolume = 66,
                UnitPrice = 0.1
            });

            data.Add(new Data
            {
                CustomerName = "Bio Concept",
                FirstQuarterVolume = 22,
                SecondQuarterVolume = 56,
                ThirdQuarterVolume = 16,
                UnitPrice = 0.14
            });

            data.Add(new Data
            {
                CustomerName = "Fast & Good",
                FirstQuarterVolume = 81,
                SecondQuarterVolume = 67,
                ThirdQuarterVolume = 73,
                UnitPrice = 0.22
            });

            return data;
        }
    }
}
