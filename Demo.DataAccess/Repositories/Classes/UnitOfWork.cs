using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork 
    {
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(IDepartmentRepository departmentRepository , IEmployeeRepository employeeRepository, ApplicationDbContext dbContext)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _context = dbContext;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public IDepartmentRepository DepartmentRepository => _departmentRepository;

        public int SaveChanges()=> _context.SaveChanges();
        
        
    }
}
