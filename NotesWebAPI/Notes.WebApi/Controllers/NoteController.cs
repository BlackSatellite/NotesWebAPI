using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNotesList;
using Notes.WebApi.Models;

using System;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;
        public NoteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<NoteListViewModel>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };

            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<NoteDetailsViewModel>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };

            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            CreateNoteCommand command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;

            Guid noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
