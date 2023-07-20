using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spargo_Technology_Test_Project.Models.ViewModels;
using Spargo_Technology_Test_Project.Services;

namespace Spargo_Technology_Test_Project.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IDataService _service;

        public PharmacyController(IDataService service)
        {
            _service = service;
        }

        // GET: PharmacyController
        public ActionResult Index()
        {
            return View(_service.GetAllPharmacy());
        }

        public string GetPharmacyList()
        {
            return JsonSerializer.Serialize(_service.GetAllPharmacy());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PharmacyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PharmacyModel model)
        {
            try
            {
                _service.CreatePharmacy(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(Guid id)
        {                
                _service.DeletePharmacy(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
