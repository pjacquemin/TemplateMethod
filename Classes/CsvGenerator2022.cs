using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace Classes
{
    public class CsvGenerator2022 : CsvGenerator
    {
        public CsvGenerator2022(IEnumerable<Data> data) : base(data)
        {

        }

        protected override void DoInitFile()
        {
            string customerNameWithoutSpaces = currentProcessedData.CustomerName.Replace(" ", "");
            writer = new StreamWriter($"c:\\temp\\output_{customerNameWithoutSpaces}_2022.csv");
        }

        protected override void DoAddData()
        {
            dynamic record = new ExpandoObject();

            record.CustomerName = currentProcessedData.CustomerName;
            record.FirstQuarterVolume = currentProcessedData.FirstQuarterVolume;
            record.SecondQuarterVolume = currentProcessedData.SecondQuarterVolume;
            record.ThirdQuarterVolume = currentProcessedData.ThirdQuarterVolume;
            record.UnitPrice = currentProcessedData.UnitPrice;
            record.TotalYearResults = (currentProcessedData.FirstQuarterVolume + currentProcessedData.SecondQuarterVolume + currentProcessedData.ThirdQuarterVolume) * currentProcessedData.UnitPrice;

            records.Add(record);
        }
    }
}
