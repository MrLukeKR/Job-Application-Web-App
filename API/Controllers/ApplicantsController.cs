using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /*
    Applicants Controller is responsible for retrieving applicant information from the 
    API for display in the 'Admin Mode' of the frontend
    */
    public class ApplicantsController : BaseController
    {
        // Reference to the backend database
        private readonly DataContext _context;

        // Constructor assigns a reference to the database
        public ApplicantsController(DataContext context) { _context = context; }

        /*
        API endpoint to get all Applicant information from the database asynchronously,
        to enable scalability of the application
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        {
            // Return applicant information via the '/api/applicants' endpoint. 
            // Includes nested address entities.
            return await _context.Applicants.Include(applicant => applicant.HomeAddress).ToListAsync();
        }
    }
}