using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.BusinessLogic.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee) =>
            new()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType
            };

        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee employee) =>
            new()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType
            };

        public static Employee ToEntity(this CreatedEmployeeDto dto) =>
            new()
            {
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                IsActive = dto.IsActive,
                Salary = dto.Salary,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HiringDate = dto.HiringDate,
                Gender = dto.Gender,
                EmployeeType = dto.EmployeeType
            };

        public static Employee ToEntity(this UpdatedEmployeeDto dto) =>
            new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                IsActive = dto.IsActive,
                Salary = dto.Salary,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HiringDate = dto.HiringDate,
                Gender = dto.Gender,
                EmployeeType = dto.EmployeeType
            };
    }
}

