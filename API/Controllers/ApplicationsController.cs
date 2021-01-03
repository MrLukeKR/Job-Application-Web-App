using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.DTOs;

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
        public async Task<ActionResult<Applicant>> Apply(ApplicationDTO application)
        {
            var newApplicant = new Applicant
            {
                Forename = application.Forename,
                Surname = application.Surname,
                EmailAddress = application.EmailAddress,
                HomePhone = application.HomePhone,
                MobilePhone = application.MobilePhone,
                StartDate = application.StartDate
            };

            newApplicant.HomeAddress = new Address
            {
                Address1 = application.address1,
                Address2 = application.address2,
                Address3 = application.address3,
                Town = application.town,
                County = application.county,
                Postcode = application.postcode
            };

            // Start tracking new applicant
            _context.Applicants.Add(newApplicant);

            // Commit applicant to database
            await _context.SaveChangesAsync();

            return newApplicant;
        }
    }
}