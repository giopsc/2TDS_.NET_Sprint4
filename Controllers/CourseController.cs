using Doracorde.Repository;
using Doracorde.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doracorde.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Courses")]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _repositoryCourse;

        public CourseController(IRepository<Course> repositoryCourse)
        {
            _repositoryCourse = repositoryCourse;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            _repositoryCourse.Add(course);

            return Created();
        }
    }
}
