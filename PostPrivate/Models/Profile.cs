using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostPrivate.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FName { get; set; }
        public string MName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required, Range(13, 120)]
        public int Age { get; set; }
        public string DateJoined { get; set; }
        public DateTime BDay { get; set; }

        //public int[] FriendsList { get; set; }
        public string Bio { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNum { get; set; }
        public string WorkPlace { get; set; }
        public string School { get; set; }
        public string HomeTown { get; set; }
        public string PhotoName { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Friend> FriendsWith { get; set; }
        public ICollection<Friend> FriendsFrom { get; set;}
        //public ApplicationUser User { get; set; }
        //public string ApplicationUserId { get; set; }
        public string IdentityUserId { get; set; }
    }
}
