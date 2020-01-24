using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostPrivate.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ProfileId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Post Post { get; set; }
        public Profile Profile { get; set; }
    }
}
