using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MarkPackReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppboxController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AppboxController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.AppBoxProcess.ToList();
            return Ok(data);
        }
    }
}
