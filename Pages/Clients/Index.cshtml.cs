using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using CarDealership.ViewModels;
using System.Security.Policy;

namespace CarDealership.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Data.CarDealershipContext _context;

        public IndexModel(CarDealership.Data.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get; set; } = default!;
        public ClientIndexData ClientData { get; set; }
        public int ClientID { get; set; }
        public int CarsID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            ClientData = new ClientIndexData();
            ClientData.Clients = await _context.Client
            .Include(i => i.Brands)
            .Include(b => b.TD)

            .OrderBy(i => i.Phone)
            .ToListAsync();
            if (id != null)
            {
                ClientID = id.Value;
                Client client = ClientData.Clients
                .Where(i => i.ID == id.Value).Single();
                ClientData.Brands = client.Brands;
            }
        }

        private async Task OnGetAsync1()
        {
            Client = await _context.Client.ToListAsync();
        }
    }
}
