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

        public IList<Cars> Cars { get;set; } = default!;
        public string BrandSort { get; set; }
        public string ManufactureSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            BrandSort = String.IsNullOrEmpty(sortOrder) ? "Brand_desc" : "";
            ManufactureSort = sortOrder == "Manufacture" ? "Manufacure_desc" : "Manufacture";


            Cars = await _context.Cars
                .Include(b => b.Client)
                .ToListAsync();
        }
    }
}
