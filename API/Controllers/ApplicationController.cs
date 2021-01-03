using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ApplicationController : BaseController
    {
        private readonly DataContext _context;

        public ApplicationController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("apply")]
        public async Task<ActionResult<Applicant>> Apply(string forename, string surname, string emailAddress, string homePhone, string mobilePhone, DateTime startDate)
        {
            var newApplicant = new Applicant
            {
                Forename = forename,
                Surname = surname,
                EmailAddress = emailAddress,
                //address: Address;   
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                StartDate = startDate
            };

            // Start tracking new applicant
            _context.Applicants.Add(newApplicant);

            // Commit applicant to database
            await _context.SaveChangesAsync();

            return newApplicant;
        }
    }
}