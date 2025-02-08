using TestProject.Data;
using TestProject.Interface;
using TestProject.Models;

namespace TestProject.Services
{
    public class DataManager : IDataManger
    {
        private readonly AppDbContext _db;
        private CSVDataManager _csvManager = new CSVDataManager();
        public DataManager(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customer>> LoadData()
        {
            try
            {
                List<Customer> Cumtomer = _db.Customer.ToList();
                return Cumtomer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SaveData(List<Customer> Customer)
        {
            try
            {
                _db.Customer.AddRange(Customer);
                await _db.SaveChangesAsync();
                await _csvManager.SaveData(Customer);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
