using System;
using System.Threading;
using System.Threading.Tasks;
using domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persistence;

namespace application.Features.Employees
{
    public class DeleteEmployee
    {
        public class DeleteEmployeeCommand : IRequest<Employee>
        { 
            public int Id { get; set; }
        }
        
        public class  DeleteEmployeeHandler :IRequestHandler <DeleteEmployeeCommand, Employee>
        {
            private readonly DataContext _context;

            public DeleteEmployeeHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<Employee> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var  employee = await _context.Employees.FindAsync(request.Id);
                if (employee is null)
                {
                    throw new Exception("No Employer Found");
                }

                _context.Employees.Remove(employee);
              
                var result = await _context.SaveChangesAsync();

                if (result < 1)
                {
                    throw new Exception("Fail to delete the Employee");
                }

                return employee;
            }
        }
    }
    
    
}