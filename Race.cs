using System;
using System.Collections.Generic;

#nullable disable

namespace NotesService.Models
{
    public partial class Race
    {
        public Race()
        {
            Users = new HashSet<User>();
        }

        public int RaceId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
