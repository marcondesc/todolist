using Microsoft.AspNetCore.Mvc;
using TWTodoList.Contexts;
using TWTodoList.Models;
using TWTodoList.ViewModels;

namespace TWTodoList.Controllers;

public class TodoController : Controller
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }



    public IActionResult Index()
    {
        var todos = _context.Todos.ToList();
        var viewModel = new ListTodoViewModel { Todos = todos };
        ViewData["Title"] = "Lista de Tarefas";
        return View(viewModel);

        // outra forma de fazer - sem usar viewmodel
        //IEnumerable<Todo> objTodoList = _context.Todos;
        //return View(objTodoList);

    }
}