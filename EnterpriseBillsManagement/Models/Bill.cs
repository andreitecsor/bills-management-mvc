namespace EnterpriseBillsManagement.Models
{
    public enum BillType
    {
        Gas,
        Electricity,
        Water,
        Internet,
        Phone
    }
    public class Bill
    {
        public long Id { get; set; }
        public string? Provider { get; set; }
        public BillType Type { get; set; }
        public decimal Price { get; set; }
        public DateOnly dueDate { get; set; }
        public Company? Client { get; set; }
    }
}
