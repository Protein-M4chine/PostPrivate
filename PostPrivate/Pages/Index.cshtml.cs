using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PostPrivate.Data;
using PostPrivate.Models;
using PostPrivate.Services;

namespace PostPrivate.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public string UserId;
        public IEnumerable<Post> NewsFeed;
        public IQueryable<Profile> SuggestedFriendsList;
        public IEnumerable<Profile> SuggestedList;
        public Profile Profile { get; private set; }
        public Post Post { get; set; }
        public bool noPostsExist;
        public IndexModel(ApplicationDbContext context)
        {          
            _context = context;
        }     
        public IActionResult OnGet()
        {
            noPostsExist = (_context.Posts.ToList().Count < 1);

            UserId = User.GetUserId();

            Profile = _context.Profiles.FirstOrDefault(p => p.IdentityUserId == UserId);

            NewsFeed = _context.Posts.ToList().Where(p => p.ProfileId == Profile.Id).OrderByDescending(p => p.TimpeStamp);

            //var SuggestedFriendsList = _context.Profiles.Join(
            //        _context.Friends,
            //        p => p.Id,
            //        f => f.ProfileId).Where(f => f.FriendProfileId != Profile.Id).Select();
            //SuggestedFriendsList = from profile in _context.Profiles
            //                           join friend in _context.Friends
            //                           on profile.Id equals friend.WithId
            //                           where Profile.Id != friend.FromId
            //                           select profile;\
            SuggestedList = _context.Profiles.ToList();

            if (Profile == null)
            {
                return RedirectToPage("/userprofile/create");
            }

            return Page();
        }
        
        public PartialViewResult OnPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return Partial("/_ErrorPartial");
            }
            else
            {
                //4. Get current user Id

                UserId = User.GetUserId();

                //1. Get current user profile
                Profile = _context.Profiles.FirstOrDefault(p => p.IdentityUserId == UserId);

                //2 Set incoming post's foreign pointer to the current user profile
                post.ProfileId = Profile.Id;

                //3. Add new post to database
                _context.Add(post);
                _context.SaveChangesAsync();


                //5. Update IndexModel properties with updated NewsFeed          

                //6. Retreive posts (updated list) from the database for the current user 
                NewsFeed = _context.Posts.ToList().Where(p => p.ProfileId == Profile.Id).OrderByDescending(p => p.TimpeStamp);
                //7. Return Partial View Result

                return Partial("/Pages/Shared/_NewsFeedPartial.cshtml", NewsFeed);
            }
        }
    }
}
