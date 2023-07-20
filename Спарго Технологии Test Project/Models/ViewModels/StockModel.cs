using System.ComponentModel.DataAnnotations;

namespace Spargo_Technology_Test_Project.Models.ViewModels
{
    public class StockModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите название склада")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Выберите аптеку")]
        public PharmacyModel Pharmacy { get; set; }
    }
}
