using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostPrivate.Data;
using PostPrivate.Models;

namespace PostPrivate
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;            
        }
        public Profile Profile { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(Profile profile)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            profile.IdentityUserId = User.GetUserId();
            _context.Add(profile);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}