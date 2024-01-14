using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Security.Policy;

namespace CarDealership.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Brand {  get; set; }
        public string Model {  get; set; }
        [Display(Name = "ManufactureDate")]

        public DateTime Manufacture {  get; set; }
      

        public int Price { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }

       

    }
}
