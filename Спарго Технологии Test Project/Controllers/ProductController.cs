using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spargo_Technology_Test_Project.Models.ViewModels;
using Spargo_Technology_Test_Project.Services;
using System.Text.Json;

namespace Spargo_Technology_Test_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDataService _service;

        public ProductController(IDataService service)
        {
            _service = service;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_service.GetAllProducts());
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult PharmaciesProducts(Guid pharmacyId)
        {           
            return View(_service.GetProductsByPharmacyId(pharmacyId));
        }

        public string GetProducts()
        {
            return JsonSerializer.Serialize(_service.GetAllProducts());
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                _service.CreateProduct(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(Guid id, bool isAllProducts)
        {
            try
            {
                _service.DeleteProduct(id);
                if (isAllProducts)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(PharmaciesProducts));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
