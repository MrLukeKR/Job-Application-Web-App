using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Controllers
{
    public class ApplicationsController : BaseController
    {
        private readonly DataContext _context;

        public ApplicationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("apply")]
        public async Task<ActionResult<Applicant>> Apply(ApplicationDTO application)
        {
            if(await ApplicantExists(application.EmailAddress)) 
                return BadRequest("Application already received for this person!");

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

        // Simple method of checking if a user exists, assuming email address as a unique index for that user.
        private async Task<bool> ApplicantExists(string emailAddress)
        {
            return await _context.Applicants.AnyAsync(x => x.EmailAddress == emailAddress);
        }

        private async Task<bool> AddressExists(string address1, string postcode)
        {
            return await _context.Address.AnyAsync(x => (x.Address1.ToLower() == address1.ToLower() && x.Postcode.ToLower() == postcode.ToLower()));
        }

        private async Task<Address> GetAddress(string address1, string postcode){
            if(await AddressExists(address1, postcode))
                return await _context.Address.SingleAsync(
                    x => (x.Address1.ToLower() == address1.ToLower() && x.Postcode.ToLower() == postcode.ToLower())
                );
            else
                return null;
        }
    }
}