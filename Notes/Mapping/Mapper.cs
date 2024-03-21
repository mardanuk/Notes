using Notes.Domain;
using Presentation.DTOs;

namespace Presentation.Mapping
{
    public static class Mapper 
    {
        public static NoteDto? MapTo(this Note? note)
        {
            return note != null
                ? new NoteDto { Header = note.Header, Text = note.Text }
                : null;
        }
        public static Note? MapTo(this NoteDto? note)
        {
            return note != null
                ? new Note { Header = note.Header, Text = note.Text }
                : null;
        }
    }
}
