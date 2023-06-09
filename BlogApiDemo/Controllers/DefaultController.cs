﻿using BlogApiDemo.DataAccess;
using BlogApiDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var context = new Context();
            var values = context.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context = new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employee);
                context.SaveChanges();
                return Ok(employee);
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var context = new Context();
            var emp = context.Find<Employee>(employee.Id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                context.Update(emp);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
