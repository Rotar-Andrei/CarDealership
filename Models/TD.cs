namespace CarDealership.Models
{
    public class TD
    { public int ID { get; set; }

        public DateTime TestDate { get; set; }
        public ICollection<Client>? Clients { get; set; }
    }
}
