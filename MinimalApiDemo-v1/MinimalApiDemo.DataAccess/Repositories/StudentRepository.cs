using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.DataAccess.Entities;
using MinimalApiDemo.DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiDemo.DataAccess.Repositories
{
    public interface IStudentRepository
    {
        Task Create(StudentEntity student);
        Task<bool> Delete(int id);
        Task<List<StudentEntity>> GetAll();
        Task<StudentEntity?> GetById(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _db;

        public StudentRepository(UniversityDbContext db)
        {
            _db = db;
        }

        public async Task<List<StudentEntity>> GetAll()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<StudentEntity?> GetById(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(StudentEntity student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return false;
            }

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}
