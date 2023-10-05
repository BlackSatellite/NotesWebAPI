using AutoMapper;

using Notes.Application.Common.Mappings;
using Notes.Domain;

using System;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    option => option.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                    option => option.MapFrom(note => note.Title));
        }
    }
}