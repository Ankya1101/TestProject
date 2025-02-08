using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using TestProject.Interface;
using TestProject.Models;

namespace TestProject.Services
{
    public class CSVDataManager : IDataManger
    {
        private readonly string _filePath = "customer_data.csv";
        public async Task<List<Customer>> LoadData()
        {
            try
            {
                if (!File.Exists(_filePath)) return new List<Customer>();
                using var reader = new StreamReader(_filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<Customer>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SaveData(List<Customer> customerDataList)
        {
            try
            {
                //using var writer = new StreamWriter(_filePath);
                //using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                //csv.WriteRecords(customerDataList);
                //return true;

                List<Customer> existingCustomers = new List<Customer>();

                if (File.Exists(_filePath))
                {
                    using var reader = new StreamReader(_filePath);
                    CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture); // Explicitly declare type
                    existingCustomers = csv.GetRecords<Customer>().ToList();
                }

                // Append new customers to the existing ones
                existingCustomers.AddRange(customerDataList);

                // Write all records (existing + new) back to the file
                using var writer = new StreamWriter(_filePath);
                using CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture); // Explicitly declare type
                csvWriter.WriteRecords(existingCustomers);

                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}
