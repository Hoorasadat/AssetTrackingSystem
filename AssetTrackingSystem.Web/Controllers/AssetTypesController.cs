using AssetTrackingSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTrackingSystem.Web.Controllers
{
    public class AssetTypesController : Controller
    {
        private readonly IAssetTypeRepository _assetTypeRepository;

        public AssetTypesController(IAssetTypeRepository assetTypeRepository)
        {
            _assetTypeRepository = assetTypeRepository;
        }



        // GET: AssetTypesController
        public ActionResult Index()
        {
            return View();
        }



        // GET: AssetTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: AssetTypesController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: AssetTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: AssetTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: AssetTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: AssetTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: AssetTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
