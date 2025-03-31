using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.VisualBasic;

namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeServices
    {
        // Get All Employees
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking)
        {
            var employees = _employeeRepository.GetAll(WithTracking);
            var employeesDto = employees.Select(Emp => new EmployeeDto()
            {
                Id = Emp.Id,
                Name = Emp.Name,
                Age = Emp.Age,
                Email = Emp.Email,
                IsActive = Emp.IsActive,
                Salary = Emp.Salary,
                EmployeeType=Emp.EmployeeType.ToString(),
                Gender=Emp.Gender.ToString()
            });
            return employeesDto;
        }

        // Get Employee By Id
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee is null ? null : new EmployeeDetailsDto()
            {
                Id= employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
               Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                HiringDate=DateOnly.FromDateTime(employee.HiringDate),
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                EmployeeType=employee.EmployeeType.ToString(),
                Gender=employee.Gender.ToString(),
                CreatedBy=1,
                CreatedOn=employee.CreatedOn,
                LastModifiedBy=1,
                LastModifiedOn=employee.LastModifiedOn
            };
     

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

        
        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
