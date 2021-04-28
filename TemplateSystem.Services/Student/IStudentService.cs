using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Services
{
    public interface IStudentService : IDisposable
    {
        Task<List<Student>> GetAllStarsAsync();
        Task<Student> GetStudentriptionByIdAsync(int? id);
        Task AddStarAsync(Student stardesc);
        Task DeleteStarAsync(int? id);
        Task EditStudentAsync(Student stardesc);

    }
}