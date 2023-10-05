using AutoMapper;

using Notes.Application.Common.Mappings;
using Notes.Domain;

using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsViewModel : IMapWith<Note>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsViewModel>()
                .ForMember(noteViewModel => noteViewModel.Title,
                    option => option.MapFrom(note => note.Title))
                .ForMember(noteViewModel => noteViewModel.Details,
                    option => option.MapFrom(note => note.Details))
                .ForMember(noteViewModel => noteViewModel.Id,
                    option => option.MapFrom(note => note.Id))
                .ForMember(noteViewModel => noteViewModel.CreationDate,
                    option => option.MapFrom(note => note.CreationDate))
                .ForMember(noteViewModel => noteViewModel.EditDate,
                    option => option.MapFrom(note => note.EditDate));
        }
    }
}
