using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService
    {
        public IDepartmentRepository DepartmentRepository { get; }
        public DepartmentService(IDepartmentRepository departmentRepository) //Injection
        {
            DepartmentRepository = departmentRepository;
        }


    }
}
