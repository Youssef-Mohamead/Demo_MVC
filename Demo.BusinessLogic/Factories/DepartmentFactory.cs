﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Employee D)
        {
            return new DepartmentDto()
            {
                DeptId = D.Id,
                Code = D.Code,
                Description = D.Description,
                Name = D.Name,
                CreatedOn = DateOnly.FromDateTime(D.CreatedOn.GetValueOrDefault())

            };
        }
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Employee department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                CreatedBy = department.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn.GetValueOrDefault()),
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn.GetValueOrDefault()),
                ISDeleted = department.ISDeleted,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description
            };
        }
        public static Employee ToEntity(this CreatedDepartmentDto departmentDto) => new Employee()
        {
            Code = departmentDto.Code,
            Name = departmentDto.Name,
            Description = departmentDto.Description,
            CreatedOn = departmentDto.CreatedOn.ToDateTime(new TimeOnly())
        };
        
        public static Employee ToEntity(this UpdatedDepartmentDto departmentDto) => new Employee()
        {
            Id = departmentDto.Id,
            Code = departmentDto.Code,
            Name = departmentDto.Name,
            Description = departmentDto.Description,
            CreatedOn = departmentDto.CreatedOn.ToDateTime(new TimeOnly())
        };

    }
}
