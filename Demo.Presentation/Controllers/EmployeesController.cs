using Demo.BusinessLogic.DataTransferObject.DepartmentDataTransferObject;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.BusinessLogic.Services.DepartmentServices;
using Demo.BusinessLogic.Services.EmployeeServices;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enums;
using Demo.Presentation.ViewModels.EmployeeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Presentation.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices, IWebHostEnvironment environment, ILogger<EmployeesController> logger ) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeServices.GetAllEmployees();
            return View(Employees);
        }
        #region Create Employee
        [HttpGet]
        public IActionResult Create([FromServices]IDepartmentService departmentService)
        {
           return  View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var employeeDto = new CreatedEmployeeDto()
                    {
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,
                        Email = employeeViewModel.Email,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,
                        HiringDate = employeeViewModel.HiringDate,
                        IsActive = employeeViewModel.IsActive,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Salary = employeeViewModel.Salary,
                        DepartmentId = employeeViewModel.DepartmentId
                    };
                    int Result = _employeeServices.AddEmployee(employeeDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Created");

                    }
                }
                catch (Exception ex)
                {
                    // Log Exception
                    if (environment.IsDevelopment())
                    {
                        // 1. Development => Log Error In Console and Return  Same View With Error Message

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //2. Deployment => Log Error In File | Table in Database And Return Error View

                        logger.LogError(ex.Message);
                    }
                }
            }
            return View(employeeViewModel);
        }
        #endregion
        #region Details Of Employee
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emplyee = _employeeServices.GetEmployeeById(id.Value);
            return emplyee is null ? NotFound() : View(emplyee);
        }
        #endregion
        #region Edit Of Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeViewModel = new EmployeeViewModel()
            {

                Address = employee.Address,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender),

            };
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeViewModel)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(employeeViewModel);
            try
            {
                var employeeDto = new UpdatedEmployeeDto()
                {
                    Id = id.Value,
                    Name = employeeViewModel.Name,
                    Address= employeeViewModel.Address,
                    Age= employeeViewModel.Age,
                    Email = employeeViewModel.Email,
                    EmployeeType= employeeViewModel.EmployeeType,
                    Gender = employeeViewModel.Gender,
                    HiringDate= employeeViewModel.HiringDate,
                    IsActive = employeeViewModel.IsActive,
                    PhoneNumber = employeeViewModel.PhoneNumber,
                    Salary= employeeViewModel.Salary,
                    DepartmentId= employeeViewModel.DepartmentId
                };
                var Result = _employeeServices.UpdateEmployee(employeeDto);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Updated");
                    return View(employeeDto);
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeViewModel);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("Error view", ex);
                }
            }
        }
        #endregion
        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = _employeeServices.DeleteEmployee(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Emplyee IS Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                // Log Exception
                if (environment.IsDevelopment())
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }
        #endregion
    }
}
