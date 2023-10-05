using AutoMapper;

using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    option => option.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    option => option.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    option => option.MapFrom(noteDto => noteDto.Details));
        }
    }
}
