using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService) : Controller
    {
        //BaseUrl/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments= _departmentService.GetAllDepartments();
            return View(departments);
        }
    }
}
