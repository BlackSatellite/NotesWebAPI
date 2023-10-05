using MediatR;

using System;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class GetNoteListQuery : IRequest<NoteListViewModel>
    {
        public Guid UserId { get; set; }
    }
}