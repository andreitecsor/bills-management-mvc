using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseBillsManagement.Models
{
    public enum BillType
    {
        Gas,
        Electricity,
        Water,
        Internet,
        Phone,
        Other
    }
    public class Bill
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter a provider name")]
        public string? Provider { get; set; }
        [Required(ErrorMessage = "Please select a type name")]
        public BillType Type { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal Price { get; set; }
        public DateTime DueDate { get; set; }
        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
