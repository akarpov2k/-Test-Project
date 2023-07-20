using System.ComponentModel.DataAnnotations;

namespace Spargo_Technology_Test_Project.Models.ViewModels
{
    public class BatchModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Выберите продукт")]
        public ProductModel Product { get; set; }
        [Required(ErrorMessage = "Укажите название склада")]
        public StockModel Stock { get; set; }
        [Required(ErrorMessage = "Укажите количество товара")]
        [Display(Name = "Количество")]
        public int Count { get; set; }

    }
}
