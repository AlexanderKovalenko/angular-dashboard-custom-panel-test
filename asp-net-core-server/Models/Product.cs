using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDashboardBackend {
    public class Product {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsOnOrder { get; set; }
        public int? CategoryID { get; set; }
    }
}