using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;

namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        int AddEmployee(CreatedEmployeeDto employeeDto);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDetailsDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
    }
}
