using PostPrivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostPrivate.Services
{
    public class InMemoryProfileRepository : IProfileRepository
    {
        private List<Profile> _masterProfileList;
        public InMemoryProfileRepository()
        {
            _masterProfileList = new List<Profile>()
            {
                new Profile()
                {
                    Id = 1, UserName = "protein_m4chine", FName = "Sean", LName = "Robinson", Age = 27, PhotoName ="sean.jpg", DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                    Bio = "Web Developer, Drummer, Citizen-Soldier"
                },
                new Profile()
                {
                    Id = 2, UserName = "deep_chaos", FName = "Evan", LName = "Robinson", Age = 25, PhotoName = "evan.jpg", DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                    Bio = "Effects Animationist, Bass Guitarist, Very much into Politics"
                },
                new Profile()
                {
                    Id = 3, UserName = "hav0c", FName = "AJ", LName = "Robinson", Age = 22, PhotoName = "aj.jpg" , DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                    Bio = "Dronist, Guitarist, bored Alaskan"
                },
                new Profile()
                {
                    Id = 4, UserName = "bluegables", FName = "Erica", LName = "Robinson", Age = 19, PhotoName = "erica.jpg", DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                    Bio = "Student, Violinist, Student Driver"
                }
            };
        }
        public Profile GetProfile(int id)
        {
            Profile profile = _masterProfileList.FirstOrDefault(p => p.Id == id);

            return profile;
        }
        public List<Profile> GetMasterProfileList()
        {
            return _masterProfileList;
        }

    }
}
