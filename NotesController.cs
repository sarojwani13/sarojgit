using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.Models;
using NotesService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesService.Data;


namespace NotesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository noteRepository)
        {
            this._notesRepository = noteRepository;
        }


        [HttpPost]
        [Route("addNote")]
        [Authorize]
        public IActionResult AddNotes([FromBody] Note noteInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var noteDetail = new Note();
                    noteDetail.NotesTitle = noteInfo.NotesTitle;
                    noteDetail.NotesDescription = noteInfo.NotesDescription;
                    noteDetail.UrgencyLevel = noteInfo.UrgencyLevel;
                    noteDetail.ReceiverId = noteInfo.ReceiverId;
                    noteDetail.CreatedBy = noteInfo.CreatedBy;
                    noteDetail.SenderId = noteInfo.SenderId;

                    noteDetail.CreatedDate = DateTime.Now;
                    //al.ModifiedDate = allergyInfo.ModifiedDate;
                    //al.ModifiedBy = allergyInfo.ModifiedBy;
                    noteDetail.IsActive = true;

                    var response = this._notesRepository.AddNotes(noteDetail);
                    return Ok(response);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                }
            }
            return null;
        }

        [Route("getAllNotesById/{receiverId}")]
        [HttpGet]
        [Authorize]

        public ActionResult<IEnumerable<Note>> GetAllNotesById(int receiverId)
        {
            try
            {
                var result = _notesRepository.GetAllNotesById(receiverId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("replyNoteById/{senderId}")]
        [Authorize]
        public IActionResult ReplyToNoteById(int senderId, [FromBody] Note noteInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //var noteDetail = new Note();
                    //noteDetail.NotesTitle = noteInfo.NotesTitle;
                    //noteDetail.NotesId = noteInfo.NotesId;
                    //noteDetail.NotesDescription = noteInfo.NotesDescription;
                    //noteDetail.UrgencyLevel = noteInfo.UrgencyLevel;
                    //noteDetail.SenderId = noteInfo.SenderId;
                    //noteDetail.ReceiverId = noteInfo.ReceiverId;
                    //noteDetail.CreatedBy = noteInfo.CreatedBy;
                    noteInfo.CreatedDate = DateTime.Now;
                    ////al.ModifiedDate = allergyInfo.ModifiedDate;
                    ////al.ModifiedBy = allergyInfo.ModifiedBy;
                    noteInfo.IsActive = true;

                    var response = this._notesRepository.ReplyToNoteById(senderId, noteInfo );
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                }
            }
            return null;
        }


        [HttpPost]
        [Route("closeNoteById/{noteId}")]
        [Authorize]
        public IActionResult CloseNoteById(int noteId,Note noteinfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var note = _notesRepository.CloseNoteById(noteId,noteinfo);

                return Ok(note);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getAllSendNotesById/{senderId}")]
        [Authorize]

        public ActionResult<IEnumerable<Note>> GetAllSendNotesById(int senderId)
       {

            try
            {
                var result = _notesRepository.GetAllSendNotesById(senderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getNoteById/{notesId}")]
        [Authorize]

        public IActionResult GetNoteById(int notesId)
        {
            try
            {
                if (notesId == 0)
                    return BadRequest();

                Note note = new Note();
                var result = _notesRepository.GetNoteById(notesId);

                if (note != null)
                {
                    note.NotesId = result.NotesId;
                    note.ReceiverId = result.ReceiverId;
                    note.SenderId = result.SenderId;
                    note.NotesDescription = result.NotesDescription;

                    return Ok(note);

                }

                return NotFound("Note not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }
    }
}

