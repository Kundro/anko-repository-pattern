namespace Customer.Datalayer.BusinessEntities
{
    public class Customers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }
    }
}
