using CsvHelper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;

namespace Classes
{
    public class CsvGenerator : Generator
    {
        protected StreamWriter writer { get; set; }
        protected List<dynamic> records { get; set; }

        public CsvGenerator(IEnumerable<Data> datas) : base(datas) 
        {
            records = new List<dynamic>();
        }

        protected override void DoInitFile()
        {
            string customerNameWithoutSpaces = currentProcessedData.CustomerName.Replace(" ", "");
            writer = new StreamWriter($"c:\\temp\\output_{customerNameWithoutSpaces}.csv");
        }

        protected override void DoAddData()
        {
            dynamic record = new ExpandoObject();

            record.CustomerName = currentProcessedData.CustomerName;

            int yearVolume = currentProcessedData.FirstQuarterVolume + currentProcessedData.SecondQuarterVolume + currentProcessedData.ThirdQuarterVolume;
            record.TotalYearResults = yearVolume * currentProcessedData.UnitPrice;

            records.Add(record);
        }

        protected override void DoSaveFile()
        {
            using (writer)
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        protected override void HookEnd()
        {
            base.HookEnd();

            Console.WriteLine("End of Csv creation");
        }
    }
}
