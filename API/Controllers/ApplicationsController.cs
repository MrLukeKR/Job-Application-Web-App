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

            Address existingAddress = await GetAddress(application.address1, application.postcode);

            // If address doesn't exist in database, create it, else, use the ID for the existing address.
            // This is useful if there are multiple applicants from the same address, and saves data
            // redundancy in the database.
            if (existingAddress == null)
                newApplicant.HomeAddress = new Address
                {
                    Address1 = application.address1,
                    Address2 = application.address2,
                    Address3 = application.address3,
                    Town = application.town,
                    County = application.county,
                    Postcode = application.postcode
                };
            else
                newApplicant.HomeAddress = existingAddress;

            // Start tracking new applicant
            _context.Applicants.Add(newApplicant);

            // Commit applicant to database
            await _context.SaveChangesAsync();

            return newApplicant;
        }

        private async Task<Address> GetAddress(string address1, string postcode){
            return await _context.Addresses.SingleAsync(
                x => (x.Address1.ToLower() == address1.ToLower() && x.Postcode.ToLower() == postcode.ToLower())
            );
        }
    }
}