using System;
using System.Collections.Generic;

#nullable disable

namespace NotesService.Models
{
    public partial class Note
    {
        public Note()
        {
            InverseNotesReplyNavigation = new HashSet<Note>();
        }

        public int NotesId { get; set; }
        public string NotesTitle { get; set; }
        public string NotesDescription { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int? NotesReplyId { get; set; }
        public string NotesReply { get; set; }
        public int? NotesClosedBy { get; set; }
        public int? NotesRepliedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? UrgencyLevel { get; set; }
        public bool? IsActive { get; set; }

        public virtual User NotesClosedByNavigation { get; set; }
        public virtual User NotesRepliedByNavigation { get; set; }
        public virtual Note NotesReplyNavigation { get; set; }
        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
        public virtual ICollection<Note> InverseNotesReplyNavigation { get; set; }
    }
}
