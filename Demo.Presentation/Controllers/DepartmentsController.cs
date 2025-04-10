using Demo.BusinessLogic.DataTransferObject.DepartmentDataTransferObject;
using Demo.BusinessLogic.Services.DepartmentServices;
using Demo.Presentation.ViewModels.DepartmentsViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService, ILogger<DepartmentsController> _logger, IWebHostEnvironment _environment) : Controller
    {
        //BaseUrl/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {

            ViewData["Message"] = new DepartmentDto() { Name = "TestViewData" };
            ViewBag.Message = new DepartmentDto() { Name = "TestViewBag" };
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        //[ValidateAntiForgeryToken] // Action Filter
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var departmentDto = new CreatedDepartmentDto()
                    {
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        CreatedOn = departmentViewModel.CreatedOn,
                        Description= departmentViewModel.Description

                    };
                    int Result = _departmentService.AddDepartment(departmentDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Created");

                    }
                }
                catch (Exception ex)
                {
                    // Log Exception
                    if (_environment.IsDevelopment())
                    {
                        // 1. Development => Log Error In Console and Return  Same View With Error Message

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //2. Deployment => Log Error In File | Table in Database And Return Error View

                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentViewModel);
        }

        #endregion
        #region Details Of Department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();// 404
            return View(department);
        }
        #endregion
        #region Edit Of Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();// 404
            var departmentViewModel = new DepartmentViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Code = viewModel.Code,
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        CreatedOn = viewModel.CreatedOn
                    };
                    int Result = _departmentService.UpdateDepartment(UpdatedDepartment);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Department is not Updated");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(viewModel);
        }
        #endregion
        #region Delete Department
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound();
        //    return View(department);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = _departmentService.DeleteDepartment(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department IS Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                // Log Exception
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error In Console and Return  Same View With Error Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    //2. Deployment => Log Error In File | Table in Database And Return Error View

                    _logger.LogError(ex.Message);
                    return View("ErrorView",ex);
                }
            }
        }
        #endregion
    }
}
