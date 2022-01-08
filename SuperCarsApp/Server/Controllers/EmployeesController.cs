using SuperCarsApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperCarsApp.Server.Data;
using Microsoft.AspNetCore.Authorization;

namespace MarketPlace.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            
            return await context.Employees.ToListAsync();
        }
        [HttpGet("{id}",Name = "getEmployee")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            
            return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Employee employee)
        {
          
            context.Add(employee);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("getEmployee", new { id = employee.Id }, employee);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = new Employee { Id = id };
            context.Remove(employee);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> Put(Employee employee)
        {

            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
       
    }
}
