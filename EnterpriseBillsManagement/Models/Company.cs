namespace EnterpriseBillsManagement.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int noEmployeesOnSite { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}
