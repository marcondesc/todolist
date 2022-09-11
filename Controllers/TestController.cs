using Microsoft.AspNetCore.Mvc;
using TWTodoList.Models;
using TWTodoList.ViewModels;

namespace TWTodoList.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        var todo = new Todo
        {
            Title = "Estudar ASP.NET Core",
            Description = "Concluir o curso de ASP.NET Core da TreinaWeb"
        };
        ViewBag.Todo = todo;

        TempData["message"] = "Mensagem vinda da action Index";

        //ViewData["apresentacao"] = "Olá ASP.NET Core MVC";
        return View();
    }

    public IActionResult Message()
    {
        return View();
    }

    public IActionResult ViewModel()
    {
        var todo = new Todo
        {
            Title = "Estudar ASP.NET Core",
            Description = "Concluir o curso de ASP.NET Core da TreinaWeb"
        };
        var viewModel = new DetailsTodoViewModel
        {
            Todo = todo,
            PageTitle = "Detalhes da tarefa"
        };
        return View(viewModel);
    }
}