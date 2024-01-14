using CarDealership.Models;
using System.Security.Policy;
namespace CarDealership.ViewModels
{
    public class ClientIndexData
    {

        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Cars> Brands { get; set; }

    }
}