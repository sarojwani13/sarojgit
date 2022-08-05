﻿using System;
using System.Collections.Generic;

#nullable disable

namespace NotesService.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
