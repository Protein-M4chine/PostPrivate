using System;
using System.Collections.Generic;
using System.Text;

namespace PostPrivate.Models
{
    public class Friend
    {
        public int WithId { get; set; }
        public int FromId { get; set; }
        public Profile ProfileWith { get; set; }
        public Profile ProfileFrom { get; set; }
    }
}
