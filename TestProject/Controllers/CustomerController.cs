using Microsoft.AspNetCore.Mvc;
using TestProject.Data;
using TestProject.Interface;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDataManger _dataManager;
        public CustomerController(IDataManger dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Customer> cusotmers = await _dataManager.LoadData();
            return View(cusotmers);
        }


        [HttpPost]
        public async Task<IActionResult> SetData(List<Customer> CustomerList)
        {
            try
            {
                bool isSave = await _dataManager.SaveData(CustomerList);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Index");
            }
        }
    }
}
