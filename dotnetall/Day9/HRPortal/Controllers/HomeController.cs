using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HRPortal.Models;
using BLL;
using BOL;
namespace HRPortal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Register(){ 
        return View();
    }


    [HttpPost]
    public IActionResult Register(int EmployeeId,string EmployeeName, string Email, string Password){
        BusinessLayer.InsertData(EmployeeId,EmployeeName, Email, Password);
        return RedirectToAction("Login");
    }

    public IActionResult Login(){
        return View();
    }

    static Employee validemployee;
    [HttpPost]
    public IActionResult Login(string Email, string Password){
        validemployee = BusinessLayer.Login(Email, Password);
        if(validemployee!=null){
            ViewData["employee"]=validemployee;
            return RedirectToAction("Profile");
        }
        else{
            ViewData["msg"]="Invalid Credentials!!!";
        }
        return View();
    }

    public IActionResult Profile(){
        List<Employee> allEmployee = BusinessLayer.ViewAllEmployee();
        ViewData["emp"]=allEmployee;
        return View();
    }


    public IActionResult Edit(int id){
        List<Employee> allEmployee = BusinessLayer.ViewAllEmployee();
        Employee emp = allEmployee.Find((e)=>e.EmployeeId==id);
        ViewData["emp"]=emp;
        return View();
    }
    [HttpPost]
    public IActionResult Edit(int EmployeeId, string EmployeeName, string Email, string Password){
        BusinessLayer.EditEmployee(EmployeeId,EmployeeName, Email, Password);
        return RedirectToAction("Profile");
    }

    public IActionResult Delete(int id){
        List<Employee> allEmployee = BusinessLayer.ViewAllEmployee();
        Employee emp = allEmployee.Find((e)=>e.EmployeeId==id);
        ViewData["emp"]=emp;
        BusinessLayer.DeleteEmployee(emp);
        return RedirectToAction("Profile");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
