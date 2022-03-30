using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using domain;
using FluentValidation;
using persistence;

namespace application.Features.Employees
{
    public class AddEmployee
    {
        public class AddEmployerCommand : IRequest<Employee>
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
        
        public class AddEmployeeValidator: AbstractValidator<AddEmployerCommand> 
        {
            public AddEmployeeValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Name).NotEmpty();
            }
            
        }
        
        public class  AddEmployeeHandler:IRequestHandler<AddEmployerCommand,Employee>
        {
            private readonly DataContext _context;

            public AddEmployeeHandler(DataContext context)
            {
                _context = context;
            }

            public  async Task<Employee> Handle(AddEmployerCommand request, CancellationToken cancellationToken)
            {
                var employee = new Employee()
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                await _context.Employees.AddAsync(employee);
                var result = await _context.SaveChangesAsync();
                if (result < 1)
                {
                    throw new Exception("Fail to save Employee");
                }

                return employee;
            }
        }
    }
}