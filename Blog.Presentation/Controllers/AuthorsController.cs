using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.DataAccessCommand.Context;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Enums;
using MediatR;
using Newtonsoft.Json;

namespace Blog.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {

            var query = new GetAllAuthorQuery();
            var result = await _mediator.Send(query);
            return result.ToList();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {

            var author = await _mediator.Send(new GetAuthorByIdQuery(id));

            if (author == null)
            {
                return NotFound(new { status = 404, into = "کاربری یافت نشد." });
            }

            return author;


        }



        //// PUT: api/Authors/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            var query = new AddAuthorCommand()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                UserName = author.UserName
            };
            var result = await _mediator.Send(query);

            switch (result)
            {
                case ResultStatus.Success:
                    return Ok(new { status = 201, info = "ثبت کاربر با موفقیت انجام شد." });
                case ResultStatus.Error:
                    return BadRequest(new { status = 400, into = "خطایی رخ داده است." });
                case ResultStatus.Failed:
                    return BadRequest(new { status = 400, into = "خطایی رخ داده است." });
                case ResultStatus.EmailExist:
                    return BadRequest(new { status = 400, into = "ایمیل وارد شده تکراری می باشد." });
                case ResultStatus.UserNameExist:
                    return BadRequest(new { status = 400, into = "نام کاربری وارد شده تکراری می باشد." });
                default:
                    return BadRequest(new { status = 400, into = "خطایی رخ داده است." });
            }

        }

        //// DELETE: api/Authors/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Author>> DeleteAuthor(int id)
        //{
        //    var author = await _context.Authors.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Authors.Remove(author);
        //    await _context.SaveChangesAsync();

        //    return author;
        //}

        //private bool AuthorExists(int id)
        //{
        //    return _context.Authors.Any(e => e.Id == id);
        //}
    }
}
