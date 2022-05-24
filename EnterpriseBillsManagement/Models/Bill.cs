using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(12, 4)")]
        public decimal Price { get; set; }
        public DateTime dueDate { get; set; }
        public Company? Client { get; set; }
    }
}
