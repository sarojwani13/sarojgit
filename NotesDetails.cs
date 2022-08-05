using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Dtos
{
    public class NotesDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Designation { get; set; }
        public bool? UrgencyLevel { get; set; }
        public int SenderId { get; set; }
        public DateTime? CreatedDate { get; set; }

        
    }
}
