using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.MVCCoreWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Asp.MVCCoreWeb.Controllers
{
   
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly UserManager<ApplicationUser> usermanager;

        public EmployeeController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> SignInManager)
        {
            this.usermanager = usermanager;
            this.SignInManager = SignInManager;
        }

      



        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult AddorEdit(int id = 0)
        {
            return View(new Employee());

        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> AddorEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { 
                    UserName = employee.Phone,
                    PhoneNumber = employee.Phone ,
                    PubG_UserName = employee.PubG_UserName
                };
                var result = await usermanager.CreateAsync(user, employee.Password);
       
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                 
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(employee);
        }


        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
