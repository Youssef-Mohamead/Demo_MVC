using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.Contexts;

namespace Demo.DataAccess.Repositories
{
    //Primary Constructor .Net 8 C#12
     class DepartmentRepository(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        //CRUD OPerations
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList(); 
        }
      
    }
}
