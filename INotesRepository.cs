using NotesService.Data;
using NotesService.Dtos;
using NotesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Repository
{
  public  interface INotesRepository
    {
        bool AddNotes(Note note);

        IEnumerable<Note> GetAllNotesById(int receiverId);

        IEnumerable<Note> GetAllSendNotesById(int senderId);
        Note GetNoteById(int notesId);
        bool ReplyToNoteById(int senderId,Note note);

       Response CloseNoteById(int noteId, Note note);




    }
}
