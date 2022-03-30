using System.Collections.Generic;
using System.Threading.Tasks;
using application.Features.Employees;
using domain;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class EmployeeController: BaseController 
    {
        
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee( AddEmployee.AddEmployerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IReadOnlyList<Employee>> ListEmployee()
        {
            return await Mediator.Send(new ListEmployee.ListEmployeesQuery());
        }
        
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            return await Mediator.Send(new DeleteEmployee.DeleteEmployeeCommand{Id = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id , UpdateEmployee.UpdateEmployeeCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

    }
}