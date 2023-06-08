using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.DatabasePoC.Database.Database;

namespace NitelikliGenc.DatabasePoC.Database.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly DataContext _dataContext;
    public EmployeeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _dataContext.Employees.Include(x => x.Department).ToList();
        return Ok(employees);
    }

    [HttpGet("{id}/Department")]
    public IActionResult GetById(int id)
    {
        var employee = _dataContext.Employees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }
}