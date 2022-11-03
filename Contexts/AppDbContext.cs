using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TWTodoList.EntityConfigs;
using TWTodoList.Models;

namespace TWTodoList.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=MCWS\\SQL2019;Database=mcws;Trusted_Connection=True;");
    }

    // se não for utiliza DataAnnotations
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TodoEntityConfig());
    }
}