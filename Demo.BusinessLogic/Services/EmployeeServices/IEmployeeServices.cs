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
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking=false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int AddEmployee(CreatedEmployeeDto employeeDto);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
    }
}
