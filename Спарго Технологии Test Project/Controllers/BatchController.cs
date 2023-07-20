using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spargo_Technology_Test_Project.Models;
using Spargo_Technology_Test_Project.Models.ViewModels;
using Spargo_Technology_Test_Project.Services;

namespace Spargo_Technology_Test_Project.Controllers
{
    public class BatchController : Controller
    {
        private readonly IDataService _service;

        public BatchController(IDataService service)
        {
            _service = service;
        }

        // GET: BatchController
        public ActionResult Index()
        {            
            return View(_service.GetAllBatch());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult BatchesByStock(Guid stockId)
        {
            return View("Index", _service.GetBatchesByStockId(stockId));
        }

        // POST: BatchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BatchModel model)
        {
            try
            {
                _service.CreateBatch(model);
                return RedirectToAction(nameof(Index),"Stock");
            }
            catch
            {
                return View(model);
            }
        }
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.DeleteBatch(id);
                return RedirectToAction(nameof(Index), "Stock");
            }
            catch
            {
                return View();
            }
        }
    }
}
