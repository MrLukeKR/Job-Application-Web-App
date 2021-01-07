using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    /*
    Applicant Domain entity, used to create database tables using Code-First 
    */
    public class Applicant
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Forename must have a length between 2 and 30 characters")]
        [DataType(DataType.Text)]
        public string Forename { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Surname must have a length between 2 and 30 characters")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
        [Required]
        public Address HomeAddress { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone{ get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}