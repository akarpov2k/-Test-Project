using System.ComponentModel.DataAnnotations;

namespace Spargo_Technology_Test_Project.Models.ViewModels
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите название товара")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
