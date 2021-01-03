using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Address
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }
        
        [DataType(DataType.Text)]
        public string Address2 { get; set; }
        
        [DataType(DataType.Text)]
        public string Address3 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Town { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string County { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }
    }
}