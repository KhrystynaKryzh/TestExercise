using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestExercise.Models;

namespace TestExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        Employees emp = new Employees();
        [HttpGet]
        [Route("employees")]
        public IActionResult EmployeesList()
        {
            return Ok(emp.GetEmployees());
        }

       
        [HttpPost]
        [Route("addEmployee")]
        public IActionResult Employee(string FirstName, string MiddleInitial, string LastName, string Address, string DateOfBirth, Int32 SSN)
        {
            try
            {
                return Ok(emp.AddEmployee(FirstName, MiddleInitial, LastName, Address, DateOfBirth, SSN));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteEmp(int PersonId)
        {
            try
            {
                return Ok(emp.DeleteEmp(PersonId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult EditEmp (int PersonID, string FirstName, string MiddleInitial, string LastName, string Address,string DateOfBirth, int SSN)
        {
            try
            {
                return Ok( emp.EditEmp(PersonID, FirstName,  MiddleInitial, LastName,  Address, DateOfBirth, SSN));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


    }
}
