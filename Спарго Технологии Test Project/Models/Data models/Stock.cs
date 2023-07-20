using System.ComponentModel.DataAnnotations.Schema;

namespace Spargo_Technology_Test_Project.Models.Data_models
{
    public class Stock
    {
        public Guid Id { get; set; }
        public Pharmacy Pharmacy { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string Name { get; set; }
    }
}
