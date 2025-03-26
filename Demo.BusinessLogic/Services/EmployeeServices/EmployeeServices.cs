using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeServices
    {
        // Get All Employees
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return employees.Select(E => E.ToEmployeeDto());
        }

        // Get Employee By Id
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee?.ToEmployeeDetailsDto();
        }

        // Create New Employee
        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = employeeDto.ToEntity();
            return _employeeRepository.Add(employee);
        }

        // Update Employee
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(employeeDto.ToEntity());
        }
    }
}
