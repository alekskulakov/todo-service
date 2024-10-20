using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoService.Web.Db;

namespace TodoService.Web
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var configuration = builder.Configuration;
            ConfigureEf(builder.Services, configuration.GetConnectionString("DefaultConnection"));

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TodoContext>();
                db.Database.Migrate();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/list", (TodoContext context) =>
                {
                    var allTodos = context.Todos.ToArray();
                    return allTodos;
                })
                .WithName("GetAllTodos")
                .WithOpenApi();
            
            app.MapGet("/list-with-deleted", (TodoContext context) =>
                {
                    var allTodos = context.Todos.IgnoreQueryFilters().ToArray();
                    return allTodos;
                })
                .WithName("GetAllTodosWithDeleted")
                .WithOpenApi();
            
            app.MapPost("/create", async (TodoContext context, Todo createRequest) =>
                {
                    context.Todos.Add(createRequest);
                    await context.SaveChangesAsync();
                    
                    var createdTodo = await context.Todos.FirstOrDefaultAsync(m => m.Id == createRequest.Id);
                    return Results.Ok(createdTodo);
                })
                .WithName("CreateTodo")
                .WithOpenApi();

            app.MapPut("/update", async (TodoContext context, Todo updateRequest) =>
                {
                    var todoToUpdate = await context.Todos.FirstOrDefaultAsync(m => m.Id == updateRequest.Id);
                    if (todoToUpdate == null)
                    {
                        return Results.NotFound();
                    }
                    todoToUpdate.Title = updateRequest.Title;
                    todoToUpdate.Description = updateRequest.Description;
                    await context.SaveChangesAsync();
     
                    var updatedTodo = await context.Todos.FirstOrDefaultAsync(m => m.Id == updateRequest.Id);
                    return Results.Ok(updatedTodo);
                })
                .WithName("UpdateTodo")
                .WithOpenApi();
            
            app.MapDelete("/delete", async (TodoContext context, [FromQuery]int id) =>
                {
                    var todoToRemove = await context.Todos.FirstOrDefaultAsync(m => m.Id == id);
                    if (todoToRemove == null)
                    {
                        return Results.NotFound();
                    }

                    context.Todos.Remove(todoToRemove);
                    await context.SaveChangesAsync();
                    return Results.Ok($"Todo with Id={id} has been deleted");
                })
                .WithName("DeleteTodo")
                .WithOpenApi();
            
            app.Run();
        }

        private static void ConfigureEf(IServiceCollection services, string? connectionString)
        {
            Console.WriteLine(connectionString);

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            services.AddDbContext<TodoContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
        }
    }
}


