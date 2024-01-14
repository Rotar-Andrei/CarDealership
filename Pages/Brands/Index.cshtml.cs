using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public IndexModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Cars> Cars { get; set; } = default!;
        public string BrandSort { get; set; }
        public string ManufactureSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            BrandSort = String.IsNullOrEmpty(sortOrder) ? "Brand_desc" : "";
            ManufactureSort = sortOrder == "Manufacture" ? "Manufacture_desc" : "Manufacture";

            CurrentFilter = searchString;

            IQueryable<Cars> carsQuery = _context.Cars.Include(b => b.Client);

            switch (sortOrder)
            {
                case "Brand_desc":
                    carsQuery = carsQuery.OrderByDescending(s => s.Brand);
                    break;
                case "Manufacture_desc":
                    carsQuery = carsQuery.OrderByDescending(s => s.Manufacture);
                    break;
                case "Manufacture":
                    carsQuery = carsQuery.OrderBy(s => s.Manufacture);
                    break;
                default:
                    carsQuery = carsQuery.OrderBy(s => s.Brand);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                // Verificăm dacă 'Manufacture' este de tip string
                carsQuery = carsQuery.Where(s =>
                    s.Brand.Contains(searchString) ||
                    (s.Manufacture != null && s.Manufacture.ToString().Contains(searchString))
                );
            }
            Cars = await carsQuery.ToListAsync();
        }
    }
}
