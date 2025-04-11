using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObject.DepartmentDataTransferObject;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.DepartmentServices
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        // Get All Departmetns
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return departments.Select(D => D.ToDepartmentDto());
        }
        // Get Department By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
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
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.SaveChanges();

        }
        // Update Department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }
        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var Department = _unitOfWork.DepartmentRepository.GetById(id);
            if (Department is null) return false;
            else
            {
                _unitOfWork.DepartmentRepository.Delete(Department);
                int Result = _unitOfWork.SaveChanges();
                if (Result > 0) return true;
                else return false;
            }
        }
    }
}
