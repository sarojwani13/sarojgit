using System;
using System.Collections.Generic;

#nullable disable

namespace NotesService.Models
{
    public partial class User
    {
        public User()
        {
            NoteNotesClosedByNavigations = new HashSet<Note>();
            NoteNotesRepliedByNavigations = new HashSet<Note>();
            NoteReceivers = new HashSet<Note>();
            NoteSenders = new HashSet<Note>();
        }

        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public int? RaceId { get; set; }
        public int? EthnicityId { get; set; }
        public int RoleId { get; set; }
        public string LanguageKnown { get; set; }
        public string HomeAddress { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Ethinicity Ethnicity { get; set; }
        public virtual Race Race { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Note> NoteNotesClosedByNavigations { get; set; }
        public virtual ICollection<Note> NoteNotesRepliedByNavigations { get; set; }
        public virtual ICollection<Note> NoteReceivers { get; set; }
        public virtual ICollection<Note> NoteSenders { get; set; }
    }
}
