using System;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Threading.Tasks;
using domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using persistence;

namespace application.Features.Employees
{
    public class UpdateEmployee
    {
        public class UpdateEmployeeCommand: IRequest<Employee>
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
        
        public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
        {
            public UpdateEmployeeValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.PhoneNumber).NotEmpty();
              
            }
        }

        
        
        public class UpdateEmployeeHandler: IRequestHandler<UpdateEmployeeCommand, Employee>
        {
            private DataContext _context;
            public UpdateEmployeeHandler(DataContext context)
            {
                _context = context;
            }
            public async  Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                
                var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                if (employee is null)
                {
                    throw new Exception("No Employee Found");
                }

                employee.Email = request.Email;
                employee.Name = request.Name;
                employee.PhoneNumber = request.PhoneNumber;
                _context.Entry(employee).State = EntityState.Modified;
                var result = await _context.SaveChangesAsync();
                if (result < 1)
                {
                    throw new Exception("Fail to Update Employee");
                }

                return employee;
            }
        }
    }
}