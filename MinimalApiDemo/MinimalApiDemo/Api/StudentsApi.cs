using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using MinimalApiDemo.DataAccess;
using MinimalApiDemo.DataAccess.Entities;
using MinimalApiDemo.DataAccess.Repositories;

namespace MinimalApiDemo.Api
{
    public static class StudentsApi
    {
        public static void RegisterApis(WebApplication app)
        {
            // GET
            app.MapGet("/students", async (IStudentRepository repository) =>
                await repository.GetAll());

            // GET by id
            app.MapGet("/students/{id}", async (int id, IStudentRepository repository) => {
                var student = await repository.GetById(id);
                return student == null ? Results.NotFound() : Results.Ok(student);
            });

            // POST
            app.MapPost("/students", async (StudentEntity student, IStudentRepository repository) =>
            {
                await repository.Create(student);
            });

            // DELETE
            app.MapDelete("/students/{id}", async (int id, IStudentRepository repository) =>
            {
                var result = await repository.Delete(id);
                return result ? Results.Ok() : Results.NotFound();
            });
        }
    }
}
