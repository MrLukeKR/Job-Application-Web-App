using System;

namespace API.Entities
{
    public class Applicant
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public Address HomeAddress { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone{ get; set; }
        public DateTime StartDate { get; set; }
    }
}