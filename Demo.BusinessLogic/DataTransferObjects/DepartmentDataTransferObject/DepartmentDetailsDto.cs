using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.DataTransferObject.DepartmentDataTransferObject;


public class DepartmentDetailsDto
{
    ////Constructor - Based Mapping
    //public DepartmentDetailsDto(Department department)
    //{
    //    Id = department.Id;
    //    Name = department.Name;
    //    CreatedOn = DateOnly.FromDateTime((DateTime)department.CreatedOn);
    //    Code = department.Code;
    //    Description = department.Description;
    //}
    public int Id { get; set; } // PK
    public int CreatedBy { get; set; } // User Id
    public DateOnly CreatedOn { get; set; }
    public int LastModifiedBy { get; set; } // User Id
    public DateOnly LastModifiedOn { get; set; }
    public bool ISDeleted { get; set; } // Soft Delete
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
}
