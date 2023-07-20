using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spargo_Technology_Test_Project.Models.ViewModels;
using Spargo_Technology_Test_Project.Services;
using System.Text.Json;

namespace Spargo_Technology_Test_Project.Controllers
{
    public class StockController : Controller
    {
        private readonly IDataService _serivce;

        public StockController(IDataService serivce)
        {
            _serivce = serivce;
        }

        // GET: StockController
        public ActionResult Index()
        {
            return View(_serivce.GetAllStocks());
        }
        public string GetAllStocks()
        {
            return JsonSerializer.Serialize(_serivce.GetAllStocks());
        }
        // GET: StockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockModel model)
        {
            try
            {                
                _serivce.CreateStock(model);
                return RedirectToAction(nameof(Index));
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
                _serivce.DeleteStock(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
