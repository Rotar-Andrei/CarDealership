﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarDealership.Data;
using CarDealership.Models;
using System.Security.Policy;

namespace CarDealership.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public CreateModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TDID"] = new SelectList(_context.Set<TD>(), "ID",
"TestDate");

            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
