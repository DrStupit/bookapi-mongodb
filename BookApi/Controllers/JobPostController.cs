using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class JobPostController : ControllerBase
    {
        private readonly JobpostService _jobPostService;

        public JobPostController(JobpostService jobbpostService)
        {
            _jobPostService = jobbpostService;
        }

        [HttpGet]
        public ActionResult<List<JobPost>> Get() =>
            _jobPostService.Get();

        [HttpGet("{id:length(24)}", Name = "GetJob")]
        public ActionResult<JobPost> Get(string id)
        {
            var job = _jobPostService.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public ActionResult<JobPost> Create(JobPost job)
        {
            _jobPostService.Create(job);

            return CreatedAtRoute("GetJob", new { id = job.Id.ToString() }, job);
        }

        [HttpPut("{id:length(24)}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Update(string id, JobPost jobPost)
        {
            var job = _jobPostService.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            _jobPostService.Update(id, jobPost);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(string id)
        {
            var job = _jobPostService.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            _jobPostService.Remove(job.Id);

            return NoContent();
        }
    }
}