using TemplateSystem.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Services
{
    public class StudentService : IStudentService, IDisposable
    {
        private readonly IStudentRepository _StudentRepository;

        //public StudentService(IStudentRepository IStudentRepository) {
        //    _IStudentRepository = IStudentRepository;
        //}
        public StudentService()
        {
            _StudentRepository =  new StudentRepository();
           
        }

        public async Task<List<Student>> GetAllStarsAsync()
        {

            return await _StudentRepository.GetStudentAsync();
        }

        public async Task<Student> GetStudentriptionByIdAsync(int? id)
        {
           
            return await _StudentRepository.GetStudentByIdAsync(id);
        }

        public async Task AddStarAsync(Student stardesc)
        {

            await _StudentRepository.CreateStarAsync(stardesc);
        }

        public async Task DeleteStarAsync(int? id)
        {

            await _StudentRepository.DeleteStarAsync(id);
        }

        public async Task EditStudentAsync(Student stardesc)
        {

             await _StudentRepository.EditStudentAsync(stardesc);
        }

       


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _StudentRepository.Dispose();
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
        #endregion


    }
}
