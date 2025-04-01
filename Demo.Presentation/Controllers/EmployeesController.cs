using Demo.BusinessLogic.DataTransferObject.DepartmentDataTransferObject;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.BusinessLogic.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Presentation.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices, IWebHostEnvironment environment, ILogger<EmployeesController> logger) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeServices.GetAllEmployees();
            return View(Employees);
        }
        #region Create Employee
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
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
            return View(employeeDto);
        }
        #endregion
    }
}
