using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.BLL.Repositories;
using AssetTrackingSystem.Data.Data;
using AssetTrackingSystem.Lib.Models;
using AssetTrackingSystem.Web.ViewModels.Assets;
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

            DetailsAssetViewModel assetVM = new DetailsAssetViewModel()
            {
                Asset = asset,
                PageHeader = "Asset Details"
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
        public async Task<ActionResult> Create(CreateAssetViewModel createAssetVM)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }

                Asset asset = new Asset()
                {
                    TagNumber = createAssetVM.TagNumber,
                    AssetTypeId = createAssetVM.AssetTypeId,
                    ManufacturerId = createAssetVM.ManufacturerId,
                    ModelId = createAssetVM.ModelId,
                    Description = createAssetVM.Description,
                    AssignedTo = createAssetVM.AssignedTo,
                    SerialNumber = createAssetVM.SerialNumber,
                };

                await _assetRepository.AddAsset(asset);

                return RedirectToAction("Index" , "Assets");
            }
            catch
            {
                return View();
            }
        }



        // GET: AssetController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Asset asset = await _assetRepository.GetAssetsById(id);

            EditAssetViewModel assetVM = new EditAssetViewModel()
            {
                Id = asset.Id,
                TagNumber = asset.TagNumber,
                AssetTypeId = asset.AssetTypeId,
                ManufacturerId = asset.ManufacturerId,
                ModelId = asset.ModelId,
                Description = asset.Description,
                AssignedTo = asset.AssignedTo,
                SerialNumber = asset.SerialNumber
            };
            return View(assetVM);
        }



        // POST: AssetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditAssetViewModel editeAssetVM)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }

                Asset asset = new Asset()
                {
                    Id = editeAssetVM.Id,
                    TagNumber = editeAssetVM.TagNumber,
                    AssetTypeId = editeAssetVM.AssetTypeId,
                    ManufacturerId = editeAssetVM.ManufacturerId,
                    ModelId = editeAssetVM.ModelId,
                    Description = editeAssetVM.Description,
                    AssignedTo  = editeAssetVM.AssignedTo,
                    SerialNumber = editeAssetVM.SerialNumber,
                };

                await _assetRepository.UpdateAsset(asset);

                return RedirectToAction("Index", "Assets");
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
