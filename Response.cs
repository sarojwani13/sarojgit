using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Data
{
    public class Response
    {
        public bool IsSuccess { get; set; } = false;

        public string Token { get; set; }

        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public string DisplayMessage { get; set; }
    }
}
