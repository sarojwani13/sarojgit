using NotesService.Data;
using NotesService.Dtos;
using NotesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Repository
{
    public class NotesDbRepository : INotesRepository
    {
        private readonly CTAuthenticationServerDbContext _appcontext;
        public NotesDbRepository(CTAuthenticationServerDbContext appcontext)
        {
            this._appcontext = appcontext;
        }

        public bool AddNotes(Note note)
        {
            try
            {
                _appcontext.Notes.Add(note);
                _appcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<Note> GetAllNotesById(int receiverId)
        {

            return _appcontext.Notes.Where(x => x.ReceiverId == receiverId).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public Note GetNoteById(int notesId)
        {
            return _appcontext.Notes.FirstOrDefault(x => x.NotesId == notesId);
        }
        public bool ReplyToNoteById(int senderId,Note note)
        {
            try
            {
                if (note == null)
                    return false;


                //// Note noteFromDB = _appcontext.Notes.FirstOrDefault(u => u.SenderId == senderId);
                //var noteFromDB = new Note();
                ////noteFromDB.NotesId = note.NotesId;
                //noteFromDB.NotesDescription = note.NotesDescription;
                //noteFromDB.UrgencyLevel = note.UrgencyLevel;
                //noteFromDB.SenderId = note.ReceiverId;
                //noteFromDB.ReceiverId = note.SenderId;
                //note.CreatedDate = DateTime.Now;
                //note.IsActive = true;

                _appcontext.Add(note);
                _appcontext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public Response CloseNoteById(int noteId,Note note)
        {
            Note noteDetails = new Note();
            Response response = new Response();
            noteDetails = _appcontext.Notes.Where(n=>n.NotesId==noteId).FirstOrDefault();
            if (noteDetails != null)
            {
                noteDetails.IsActive = false;
               // _appcontext.Remove(noteDetails);
                _appcontext.SaveChanges();
                response.DisplayMessage = "Notes closed successfully";
                response.IsSuccess = true;
            }
            return response;      
        }

        public IEnumerable<Note> GetAllSendNotesById(int senderId)
        {
            return _appcontext.Notes.Where(x=>x.SenderId==senderId).OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
