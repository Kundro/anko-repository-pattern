﻿using System.ComponentModel.DataAnnotations;

namespace Customer.Datalayer.BusinessEntities
{
    public class Customers
    {
        public int CustomerID { get; set; }
        [StringLength(50, ErrorMessage = "First name should be less than 50.")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name should be less than 50.")]
        public string LastName { get; set; }
        [RegularExpression("^\\+[1-9]\\d{1,14}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        [RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "At least one note is required.")]
        public string Notes { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Total purchases amount is required.")]
        public decimal? TotalPurchasesAmount { get; set; }
    }
}
