using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using registration.Models;
using BoL;

namespace registration.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }
    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(int id, string fname, string lname, string email)
    {
        User u = new User();

        u.id = id;
        u.fname = fname;
        u.lname = lname;
        u.email = email;

        DBmanager.Insert(u);

        return View();
    }

    public IActionResult Display()
    {
        List<User> u = Service.GetAll();

        ViewData["display"] = u;
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Edit(int id, string fname, string lname, string email)
    {
        User u = new User();

        u.id = id;
        u.fname = fname;
        u.lname = lname;
        u.email = email;

        DBmanager.Edit(u);

        return View();

    }
    public IActionResult Delete(int id)
    {
        Console.WriteLine(id);
        DBmanager.Delete(id);
        return View();
    }


}
