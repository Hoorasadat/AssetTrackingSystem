using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.BLL.Repositories;
using AssetTrackingSystem.Data.Data;
using AssetTrackingSystem.Lib.Models;
using AssetTrackingSystem.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTrackingSystem.Web.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetRepository _assetRepository;

        public AssetsController(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }



        // GET: AssetController
        public async Task<ActionResult> Index()
        {
            IList<Asset> assets = await _assetRepository.GetAllAssets();
            return View(assets);
        }



        // GET: AssetController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //MemoryDbContext dbContext = new MemoryDbContext();
            //MockAssetRepository mockAssetRepository = new MockAssetRepository(dbContext);
            //Asset asset = await mockAssetRepository.GetAssetsById(id);

            Asset asset = await _assetRepository.GetAssetsById(id);

            //ViewData["PageTitle"] = "Asset Details";
            //ViewData["Asset"] = asset;
            //return View();

            //ViewBag.PageTitle = "Asset Details";
            //ViewBag.Asset = asset;
            //return View();

            //ViewData["PageTitle"] = "Asset Details";
            //return View(asset);

            AssetViewModel assetVM = new AssetViewModel()
            {
                Asset = asset,
                PageTitle = "Asset Details"
            };
            return View(assetVM);
        }



        // GET: AssetController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        // POST: AssetController/Create
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



        // GET: AssetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: AssetController/Edit/5
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



        // GET: AssetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: AssetController/Delete/5
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
