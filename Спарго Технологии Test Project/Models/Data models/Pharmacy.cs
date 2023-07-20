using System.ComponentModel.DataAnnotations.Schema;

namespace Spargo_Technology_Test_Project.Models.Data_models
{
    public class Pharmacy
    {
        public Guid Id { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string Address { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string Phone { get; set; }
    }
}
