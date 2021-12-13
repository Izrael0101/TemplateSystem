using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TemplateSystem.Data.Models;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Repository
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private TemplateSystemDBContext _context;

        /// <summary>
        ///     Create a new instance of <see cref="StudentRepository" />.
        /// </summary>
        /// <param name="transaction">Active transaction</param>
        /// <exception cref="ArgumentNullException">transaction</exception>
        public StudentRepository()
        {
            _context = new TemplateSystemDBContext();
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int? id)
        {
            return await _context.Student.FindAsync(id);
        }

        public async Task CreateStarAsync(Student stardesc)
        {
            _context.Student.Add(stardesc);
            await _context.SaveChangesAsync();
        }

        public async Task EditStudentAsync(Student stardesc)
        {
            _context.Entry(stardesc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStarAsync(int? id)
        {
            Student stardesc = await _context.Student.FindAsync(id);
            _context.Student.Remove(stardesc);
            await _context.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}