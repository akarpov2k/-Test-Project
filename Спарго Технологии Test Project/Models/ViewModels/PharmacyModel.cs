using System.ComponentModel.DataAnnotations;

namespace Spargo_Technology_Test_Project.Models.ViewModels
{
    public class PharmacyModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите название аптеки")]
        [Display(Name ="Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите адрес аптеки")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Укажите телефон в формате 89991112233")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Введите корректный номер телефона")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
