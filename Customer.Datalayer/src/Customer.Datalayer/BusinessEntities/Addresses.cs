using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Datalayer.BusinessEntities
{
    [Serializable]
    public class Addresses
    {
        public Addresses(){}
        public Addresses(int customerId)
        {
            CustomerId = customerId;
        }

        [Key]
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address line is required."), StringLength(100, ErrorMessage = "Address line length should be less than 100.")]
        public string AddressLine { get; set; } = string.Empty;
        [StringLength(100, ErrorMessage = "Address line length should be less than 100.")]

        public string AddressLine2 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address type is required.")]
        public string AddressType { get; set; } = "Unknown";
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required."), StringLength(50, ErrorMessage = "City name length should be less than 50.")]
        public string City { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal code is required."), StringLength(6, ErrorMessage = "Postal code length should be 6.")]

        public string PostalCode { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "State name is required."), StringLength(20, ErrorMessage = "State name length should be less than 20.")]

        public string StateName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;
    }
}
