using TestProject.Models;

namespace TestProject.Interface
{
    public interface IDataManger
    {
        Task<List<Customer>> LoadData();
        Task<bool> SaveData(List<Customer> customer);
    }
}
