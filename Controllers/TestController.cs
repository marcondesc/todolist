using Microsoft.AspNetCore.Mvc;
using TWTodoList.Models;

namespace TWTodoList.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        var todo = new Todo("Estudar Razor", DateTime.Now);
        var todo2 = new Todo("Finalizar curso de Razor logo", DateTime.Now);
        ViewData["todo"] = todo;
        ViewData["name2"] = "Marcondes Cunha";

        TempData["name"] = "mcws";

        //viewbag
        ViewBag.Name = "É ... um grande xablau!";
        ViewBag.Todo = todo2;


        return View();
    }

    public IActionResult AnotherTest()
    {
        return View();
    }

    public IActionResult ClientDetails()
    {
        var client = new Client
        {
            Name = "Marcondes Cunha",
            Email = "marcondesc@gmail.com",
            Purchases = 70,
            Type = 3
        };
        return View(client);
    }

    public IActionResult ClientList()
    {
        var clients = new List<Client>();

        clients.Add(new Client { Name = "Marcondes Cunha", Email = "marcondesc@gmail.com", Purchases = 170, Type = 3 });
        clients.Add(new Client { Name = "John Doe", Email = "doe.john@mail.com", Purchases = 2, Type = 1 });
        clients.Add(new Client { Name = "Jane Doe", Email = "jane.doe@mail.com", Purchases = 52, Type = 2 });

        return View(clients);
    }



}
