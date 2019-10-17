using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using proyecto_iic2113.Data;
namespace proyecto_iic2113.ViewComponents
{
    public class ConferenceViewComponent: ViewComponent
    {
        private ApplicationDbContext _context;
        public ConferenceViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Conferences.ToListAsync());
        }
    }
}
