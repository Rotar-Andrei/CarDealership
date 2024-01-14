using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext (DbContextOptions<CarDealershipContext> options)
            : base(options)
        {
        }

        public DbSet<CarDealership.Models.Cars> Cars { get; set; } = default!;
        public DbSet<CarDealership.Models.Client> Client { get; set; } = default!;
        public DbSet<CarDealership.Models.TD> TD { get; set; } = default!;
    }
}
