using System.ComponentModel.DataAnnotations;

namespace Customer.Datalayer.BusinessEntities
{
    public class Customers
    {
        public int CustomerID { get; set; }
        [StringLength(50, ErrorMessage = "First name should be less than 50.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name should be less than 50.")]
        public string LastName { get; set; }
        [RegularExpression("^\\+?\\d{6,7}[2-9]\\d{3}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        [RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public decimal? TotalPurchasesAmount { get; set; }
    }
}
