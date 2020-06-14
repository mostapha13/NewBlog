using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.DataAccessCommand.Context;
using Blog.Domains.Enums;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.Entities;
using Blog.Domains.Subjects.Queries;
using MediatR;

namespace Blog.Presentation.Controllers
{
 
    public class SubjectsController : BaseController
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            var result =await _mediator.Send(new GetAllSubjectQuery());
            return result.ToList();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _mediator.Send(new GetSubjectByIdQuery(id));

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        //// PUT: api/Subjects/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSubject(int id, Subject subject)
        //{
        //    if (id != subject.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(subject).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Subjects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            var query = new AddSubjectCommand()
            {
                Title = subject.Title
            };
           var result= await _mediator.Send(query);

           switch (result)
           {
                case ResultStatus.Success:
                    return Ok(new { status = 201, info = "ثبت کاربر با موفقیت انجام شد." });
                default:
                    return BadRequest(new { status = 400, into = "خطایی رخ داده است." });
           }

        }

        //// DELETE: api/Subjects/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Subject>> DeleteSubject(int id)
        //{
        //    var subject = await _context.Subjects.FindAsync(id);
        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Subjects.Remove(subject);
        //    await _context.SaveChangesAsync();

        //    return subject;
        //}

        //private bool SubjectExists(int id)
        //{
        //    return _context.Subjects.Any(e => e.Id == id);
        //}
    }
}
