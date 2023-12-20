using CQRS_Sample.Application.DTOs;
using CQRS_Sample.Infraestructure.Commands;
using CQRS_Sample.Infraestructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTask());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(int id)
        {
            var query = new GetTaskById(id);
            if (query == null) return NotFound();
            var task = await _mediator.Send(query);
            if (task == null) return NotFound();
            return task;
        }
        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> Create(CreateTask cmd)
        {
            var task = await _mediator.Send(cmd);
            if (task == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTask cmd)
        {
            if (id != cmd.Id) return BadRequest();
            var task = await _mediator.Send(cmd);
            if (task == null) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTask(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
