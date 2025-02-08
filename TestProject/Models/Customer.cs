using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
 