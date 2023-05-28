using AutoMapper;
using BusinessObject.DTOs.Employee;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return _mapper.Map<List<EmployeeDTO>>(await EmployeeDAO.GetEmployee());
        }
    }
}
