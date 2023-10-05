using System.Collections.Generic;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class NoteListViewModel
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
