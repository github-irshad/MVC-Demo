using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System. ComponentModel. DataAnnotations;


namespace ASPNETMVCCRUD.Controllers
{
    // [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly MVCDemoDbContext mvcDemoDbContext;
        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        // public EmployeesController(ILogger<EmployeesController> logger)
        // {
        //     _logger = logger;
            
        // }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDemoDbContext.Empoloyees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee(){
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                
                Department = addEmployeeRequest.Department,
                Email = addEmployeeRequest.Email
            };

            await mvcDemoDbContext.Empoloyees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await mvcDemoDbContext.Empoloyees.FirstOrDefaultAsync(x=>x.Id==id);

            if(employee != null)
            {
                var viewModel = new UpdateEmployeeModel(){
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth
                };

                return await Task.Run(() => View("View",viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult>View(UpdateEmployeeModel model)
        {
            var employee = await mvcDemoDbContext.Empoloyees.FindAsync(model.Id);

            if(employee != null)
            {
                employee.Id = model.Id;
                employee.Name = model.Name;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;
                employee.Email = model.Email;
                employee.Salary = model.Salary;

                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult>Delete(UpdateEmployeeModel model)
        {
            var employee = await mvcDemoDbContext.Empoloyees.FindAsync(model.Id);

            if(employee != null)
            {
                mvcDemoDbContext.Empoloyees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
                return RedirectToAction("Index");

        }
        

       
    }
}