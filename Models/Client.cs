using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;
using System.Security.Policy;

namespace CarDealership.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "PhoneNumber")]
        public int Phone {  get; set; }
        public string Email {  get; set; }

        public ICollection<Cars>? Brands { get; set; }

        public int? TDID { get; set; }
        public TD? TD { get; set; }
    }
}
