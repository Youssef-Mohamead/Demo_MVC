using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.VisualBasic;

namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeServices
    {
        // Get All Employees
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking)
        {
            var employees = _employeeRepository.GetAll(WithTracking);
            //Src =Employee
            //Dest = EmployeeDto
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDto;
        }

        // Get Employee By Id
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);



        }

        // Create New Employee
        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        // Update Employee
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {

            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }


        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.ISDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            }
        }
    }
}
