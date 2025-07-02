using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.NetworkInformation;
using MarkPackReport.Services;
namespace MarkPackReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBoxMarkingTrackingController : ControllerBase
    {
        private readonly AppBoxmarkingTrackingServices _service;

        public AppBoxMarkingTrackingController(AppBoxmarkingTrackingServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.LoadData();
            return Ok(data);
        }

        [HttpGet("Search")] //Search MFG 2025-06-27
        public IActionResult SearchByMFG(string pMfgNo)
        {
            if (string.IsNullOrEmpty(pMfgNo))
                return BadRequest("Please input MFGNo is required");

            var result = _service.LoadData()
                .Where(x => x.MFG.Contains(pMfgNo))
                .ToList();

            return Ok(result);
        }

        [HttpGet("Balance")]
        public IActionResult GetBalance()
        {
            var data = _service.GetDataforbalance();
            return Ok(data);
        }
    }
}
