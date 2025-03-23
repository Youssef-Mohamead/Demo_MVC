﻿
namespace Demo.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        int Delete(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetById(int id);
        int Update(Department department);
    }
}