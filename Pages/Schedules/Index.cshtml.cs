﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tech_Talks_Web_App.Business;
using Tech_Talks_Web_App.Models;

namespace Tech_Talks_Web_App.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly Tech_Talks_Web_App.Models.Tech_Talks_Web_DataContext _context;

        public IndexModel(Tech_Talks_Web_App.Models.Tech_Talks_Web_DataContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; }

        public async Task OnGetAsync()
        {
            Schedule = await _context.Schedule
                .Include(s => s.Discussion)
                .Include(s => s.Speaker)
                .Include(s => s.Sponsor).ToListAsync();
        }
    }
}
