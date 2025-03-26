using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Repositories
{
    //Primary Constructor .Net 8 C#12
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        //CRUD OPerations
        // Get Id
        public Department? GetById(int id) => _dbContext.Departments.Find(id);
        //Get All
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();

        }
        // Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
        // Delete
        public int Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

    }
}
