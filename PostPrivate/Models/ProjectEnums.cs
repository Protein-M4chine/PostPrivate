using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostPrivate.Models
{
    public class ProjectEnums
    {
        public enum School
        {
            Highschool = 0, Community_College, University, Graduate_Program
        };
        public enum PhoneType
        {
            Work, Home, Mobile
        };
        public enum Audience
        {
            Friends, FriendsOfFriends, Global
        };
    }
}
