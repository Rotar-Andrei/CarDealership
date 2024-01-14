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
    public class DetailsModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public DetailsModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public Cars Cars { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (cars == null)
            {
                return NotFound();
            }
            else
            {
                Cars = cars;
            }
            return Page();
        }
    }
}
