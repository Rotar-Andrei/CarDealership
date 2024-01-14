using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Pages.TDs
{
    public class DeleteModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public DeleteModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TD TD { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var td = await _context.TD.FirstOrDefaultAsync(m => m.ID == id);

            if (td == null)
            {
                return NotFound();
            }
            else
            {
                TD = td;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var td = await _context.TD.FindAsync(id);
            if (td != null)
            {
                TD = td;
                _context.TD.Remove(TD);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
