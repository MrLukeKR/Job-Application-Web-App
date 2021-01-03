using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ApplicationDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string Forename{ get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string address1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string address2 { get; set; }

        [DataType(DataType.Text)]
        public string address3 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string county { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string town { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string postcode { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }               
    }
}