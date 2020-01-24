using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostPrivate.Data;
using PostPrivate.Models;
using PostPrivate.Services;

namespace PostPrivate
{
    public class DetailsModel : PageModel
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ApplicationDbContext _context;

        public Profile Profile { get; private set; }
        public IEnumerable<Profile> FriendsList;
        public List<Profile> masterProfileList;

        public DetailsModel(IProfileRepository profileRepository,
                                   ApplicationDbContext context)
        {
            _profileRepository = profileRepository;
            _context = context;
        }
        public void OnGet(int id)
        {
            var UserId = User.GetUserId();
            Profile = _context.Profiles.FirstOrDefault(p => p.IdentityUserId == UserId);
            FriendsList = _context.Profiles.ToList().Where(p => p.Id != Profile.Id);
        }
    }
}