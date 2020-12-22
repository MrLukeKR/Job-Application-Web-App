using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantsController : ControllerBase
    {
        private readonly DataContext _context;
        public ApplicantsController(DataContext context)
        {
            _context = context;
        }

        /*
        API endpoint to get all Applicant information from the database asynchronously,
        to enable scalability of the application
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        {
            return await _context.Applicants.ToListAsync();
        }
    }
}