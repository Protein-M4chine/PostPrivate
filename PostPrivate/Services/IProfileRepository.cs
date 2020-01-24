using PostPrivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostPrivate.Services
{
    public interface IProfileRepository
    {
        Profile GetProfile(int id);
        List<Profile> GetMasterProfileList();
    }
}
