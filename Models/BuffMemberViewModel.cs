using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Buffteks.Models
{
    public class BuffMemberViewModel
    {

        //Members
        public List<BuffMember> buffs;
        public SelectList genres;
        public string movieGenre { get; set; }


        //Clients
        public List<BuffClient> Clientbuffs;
        public SelectList Clientgenres;
        public string buffie { get; set; }

        //Projects
        public List<BuffProject> Projectbuffs;
        public SelectList Projectgenres;
        public string projie { get; set; }
    }
}