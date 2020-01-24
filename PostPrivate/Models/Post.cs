using System;
using System.Collections.Generic;
using System.Text;

namespace PostPrivate.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string TextField { get; set; }
        public DateTime TimpeStamp { get; set; }
        public string Picture { get; set; }
        public ProjectEnums.Audience Audience { get; set; }
        public ICollection<Like> Likes { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
