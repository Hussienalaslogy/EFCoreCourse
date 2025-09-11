using System.ComponentModel.DataAnnotations;

namespace EF_CORE_API.Models
{
    public class CustomersAdresses
    {
        [Key]
        public string? CustomerNo { get; set; }
        public string? BuildingNo { get; set; }
        public string? Street { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public virtual CustomersListH? Customer { get; set; }
    }
}
