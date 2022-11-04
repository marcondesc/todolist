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

    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        _context.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastrar Tarefa";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(FormTodoViewModel dados)
    {
        var todo = new Todo(dados.Title, dados.Date);
        _context.Add(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        ViewData["Title"] = "Editar Tarefa";

        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        var viewModel = new FormTodoViewModel { Title = todo.Title, Date = todo.Date };
        return View("Form", viewModel);
    }

    [HttpPost]
    public IActionResult Edit(int id, FormTodoViewModel dados)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        todo.Title = dados.Title;
        todo.Date = dados.Date;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult ToComplete(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        todo.IsCompleted = true;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}