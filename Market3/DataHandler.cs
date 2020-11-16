using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Market.Entity
{
    public static class DataHandler
    {
        

        public static void InsertData(Price Data)
        {
            string path = "C:\\Users\\User\\source\\repos\\Market3\\Data.csv";

            var list = GetAllData();
            list.Add(Data);

            using (StreamWriter streamReader = new StreamWriter(path))
            {
                CultureInfo info = new CultureInfo("en-EN");
                CsvConfiguration configuration = new CsvConfiguration(info);
                using (CsvWriter csvReader = new CsvWriter(streamReader, configuration))
                {
                    // указываем разделитель, который будет использоваться в файле
                    csvReader.Configuration.Delimiter = ";";
                    // записываем данные в csv файл
                    csvReader.WriteRecords(list);
                }
            }
        }

        public static List<Price> GetAllData()
        {
            string path = "C:\\Users\\User\\source\\repos\\Market3\\Data.csv";
            List<Price> prices;
            using (StreamReader streamReader = new StreamReader(path))
            {
                CultureInfo info = new CultureInfo("en-EN");
                CsvConfiguration configuration = new CsvConfiguration(info);
                using (CsvReader csvReader = new CsvReader(streamReader, configuration))
                {
                    // указываем используемый разделитель
                    csvReader.Configuration.Delimiter = ";";
                    // получаем строки
                    prices = csvReader.GetRecords<Price>().ToList();
                }
            }
            return prices;
        }
    }
}
