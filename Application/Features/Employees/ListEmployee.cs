using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persistence;

namespace application.Features.Employees
{
    public class ListEmployee
    {
       

        public class ListEmployeesQuery : IRequest<IReadOnlyList<Employee>>
        {
            
        }
        public class ListEmployeeHandler:IRequestHandler<ListEmployeesQuery,IReadOnlyList< Employee>>
        {
            private readonly DataContext _context;

            public ListEmployeeHandler(DataContext context)
            {
                _context = context;
            }
            public async  Task<IReadOnlyList<Employee>> Handle(ListEmployeesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Employees.ToListAsync();
                
            }
        }
    }
}