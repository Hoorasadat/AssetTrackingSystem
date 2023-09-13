using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.BLL.Repositories;
using AssetTrackingSystem.Data.Data;
using AssetTrackingSystem.Lib.Models;
using AssetTrackingSystem.Web.ViewModels.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace AssetTrackingSystem.Web.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IAssetTypeRepository _assetTypeRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public AssetsController(IAssetRepository assetRepository, IAssetTypeRepository assetTypeRepository, IManufacturerRepository manufacturerRepository, IModelRepository modelRepository, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _assetRepository = assetRepository;
            _assetTypeRepository = assetTypeRepository;
            _manufacturerRepository = manufacturerRepository;
            _modelRepository = modelRepository;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }




        // GET: AssetController
        public async Task<ActionResult> Index(string? assignStatusFltr, string? employeeFltr, int? assetTypeFltr)
        {
            IList<Asset> assets = await _assetRepository.GetAllAssets();

            if (!string.IsNullOrEmpty(assignStatusFltr))
            {
                if (assignStatusFltr == "assigned")
                    assets = assets.Where(a => !string.IsNullOrEmpty(a.AssignedTo)).ToList();

                if (assignStatusFltr == "unassigned")
                    assets = assets.Where(a => string.IsNullOrEmpty(a.AssignedTo)).ToList();
            }

            if (!string.IsNullOrEmpty(employeeFltr))
                assets = assets.Where(a => a.AssignedTo == employeeFltr).ToList();

            if (assetTypeFltr != null)
                assets = assets.Where(a => a.AssetTypeId == assetTypeFltr).ToList();


            IList<DetailsAssetViewModel> detailsAssetVMList = new List<DetailsAssetViewModel>();

            foreach (var asset in assets)
            {
                Employee employee = new Employee();
                Department department = new Department();

                if (asset.AssignedTo == "")
                {
                    employee = null;
                    department = null;
                }
                else
                {
                    employee = await GetEmployeeAPI(asset.AssignedTo);
                    department = await GetDepartmentAPI(employee.DepartmentID);
                }
                

                DetailsAssetViewModel detailsAssetVM = new DetailsAssetViewModel()
                {
                    Asset = asset,
                    EmployeeFullName = employee == null ? null : $"{employee.FirstName } { employee.LastName }",
                    DepartmentLocation = employee == null ? null : department.Location
                };

                detailsAssetVMList.Add(detailsAssetVM);
            }

            await GetAssetTypes();

            await LoadEmployees();

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

            if (asset.AssignedTo != "")
                await LoadAssignmentInfo(asset.AssignedTo);


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
                if (!ModelState.IsValid)
                {
                    return View();
                }


                IList<Asset> assetsList = await _assetRepository.GetAllAssets();

                if (!string.IsNullOrEmpty(createAssetVM.TagNumber))
                {
                    var asset_TagNumber = assetsList.Where(a => a.TagNumber == createAssetVM.TagNumber).ToList();

                    if (asset_TagNumber.Any())
                    {
                        ModelState.AddModelError(string.Empty, $"TagNumber = {createAssetVM.TagNumber} is already taken!");
                        //return View("Create", createAssetVM);
                        return View();
                    }
                }


                if (!string.IsNullOrEmpty(createAssetVM.SerialNumber))
                {
                    var asset_SerialNumber = assetsList.Where(a => a.SerialNumber == createAssetVM.SerialNumber).ToList();

                    if (asset_SerialNumber.Any())
                    {
                        ModelState.AddModelError(string.Empty, $"SerialNumber = {createAssetVM.SerialNumber} is already taken!");
                        //return View("Create", createAssetVM);
                        return View();
                    }
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
                await LoadAssignmentInfo(asset.AssignedTo);

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


        public async Task<IList<Department>> GetDepartmentListAPI()
        {
            return await _departmentService.GetAllDepartments();
        }


        public async Task LoadDepartments()
        {
            IList<Department> departments = await GetDepartmentListAPI();

            ViewData["Departments"] = departments.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
        }


        public async Task<Department> GetDepartmentAPI(int id)
        {
            return await _departmentService.GetDepartmentById(id);
        }


        public async Task LoadAssignmentInfo (string employeeNumber)
        {
            Employee employee = await GetEmployeeAPI(employeeNumber);
            Department department = await GetDepartmentAPI(employee.DepartmentID);

            ViewData["Employee"] = employee;
            ViewData["Department"] = department;
        }
    }
}
