using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.BLL.Repositories;
using AssetTrackingSystem.Data.Data;
using AssetTrackingSystem.Lib.Models;
using AssetTrackingSystem.Web.ViewModels.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetTrackingSystem.Web.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IAssetTypeRepository _assetTypeRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IEmployeeService _employeeService;

        public AssetsController(IAssetRepository assetRepository, IAssetTypeRepository assetTypeRepository, IManufacturerRepository manufacturerRepository, IModelRepository modelRepository, IEmployeeService employeeService)
        {
            _assetRepository = assetRepository;
            _assetTypeRepository = assetTypeRepository;
            _manufacturerRepository = manufacturerRepository;
            _modelRepository = modelRepository;
            _employeeService = employeeService;
        }



        // GET: AssetController
        public async Task<ActionResult> Index()
        {
            IList<Asset> assets = await _assetRepository.GetAllAssets();

            IList<DetailsAssetViewModel> detailsAssetVMList = new List<DetailsAssetViewModel>();

            foreach (var asset in assets)
            {
                Employee employee = new Employee();

                if (asset.AssignedTo == "")
                {
                    employee = null;
                }
                else
                {
                    employee = await GetEmployeeAPI(asset.AssignedTo);
                }
                

                DetailsAssetViewModel detailsAssetVM = new DetailsAssetViewModel()
                {
                    Asset = asset,
                    EmployeeFullName = employee == null ? null : $"{employee.FirstName } { employee.LastName }"
                };

                detailsAssetVMList.Add(detailsAssetVM);
            }

            return View(detailsAssetVMList);
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

            await LoadEmployees();

            if (asset.AssignedTo != "")
                await LoadEmployee(asset.AssignedTo);

            return View(assetVM);
        }



        // GET: AssetController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await GetAssetTypes();
            await GetManufacturers();
            await GetModels();
            
            await LoadEmployees();

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

            await GetAssetTypes();
            await GetManufacturers();
            await GetModels();
            await LoadEmployees();
            if (asset.AssignedTo != "")
                await LoadEmployee(asset.AssignedTo);

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
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}



        // POST: AssetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _assetRepository.DeleteAsset(id);
                return RedirectToAction("Index", "Assets");
            }
            catch
            {
                return View();
            }
        }




        private async Task<ActionResult> GetAssetTypes()
        {
            IList<AssetType> assetTypes = await _assetTypeRepository.GetAllAssetTypes();

            ViewData["AssetTypes"] = assetTypes.Select(at => new SelectListItem { Text = at.Name, Value = at.Id.ToString() });

            return View();
        }


        private async Task<ActionResult> GetManufacturers()
        {
            IList<Manufacturer> manufacturers = await _manufacturerRepository.GetAllManufacturers();

            ViewData["Manufacturers"] = manufacturers.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });

            return View();
        }


        private async Task<ActionResult> GetModels()
        {
            IList<Model> models = await _modelRepository.GetAllModels();

            ViewData["Models"] = models.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });

            return View();
        }


        private async Task<IList<Employee>> GetEmployeesListAPI()
        {
            return await _employeeService.GetAllEmployees();
        }


        public async Task LoadEmployees()
        {
            IList<Employee> employees = await GetEmployeesListAPI();

            ViewData["Employees"] = employees.Select(e => new SelectListItem
            {
                Text = $"{e.FirstName} {e.LastName}",
                Value = e.EmployeeNumber
            });
        }


        public async Task<Employee> GetEmployeeAPI(string employeeNumber)
        {
            return await _employeeService.GetEmployeeByEmployeeNumber(employeeNumber);
        }


        public async Task LoadEmployee(string employeeNumber)
        {
            ViewData["Employee"] = await GetEmployeeAPI(employeeNumber);
        }
    }
}
