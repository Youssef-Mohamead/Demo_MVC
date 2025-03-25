using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        // Get All Departmetns
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Select(D => D.ToDepartmentDto());
        }
        // Get Department By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            //Manual Mapping
            //Auto Mapper
            //Constructor Mapping
            //extension Methods
            return department?.ToDepartmentDetailsDto();

        }

        // Create New Department
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);
        }
        // Update Department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }
        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var Department = _departmentRepository.GetById(id);
            if (Department is null) return false;
            else
            {
                int Result = _departmentRepository.Delete(Department);
                if (Result > 0) return true;
                else return false;
            }
        }
    }
}
