using TemplateSystem.Repository.StarDescs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Services
{
    public class StarDescService : IStarDescService, IDisposable
    {
        private readonly IStarDescRepository _StarDescRepository;

        //public StarDescService(IStarDescRepository IStarDescRepository) {
        //    _IStarDescRepository = IStarDescRepository;
        //}
        public StarDescService()
        {
            _StarDescRepository =  new StarDescRepository();
           
        }

        public async Task<List<StarDesc>> GetAllStarsAsync()
        {

            return await _StarDescRepository.GetStarDescsAsync();
        }

        public async Task<StarDesc> GetStarDescriptionByIdAsync(int? id)
        {
           
            return await _StarDescRepository.GetStarDescByIdAsync(id);
        }

        public async Task AddStarAsync(StarDesc stardesc)
        {

            await _StarDescRepository.CreateStarAsync(stardesc);
        }

        public async Task DeleteStarAsync(int? id)
        {

            await _StarDescRepository.DeleteStarAsync(id);
        }

        public async Task EditStarDescAsync(StarDesc stardesc)
        {

             await _StarDescRepository.EditStarDescAsync(stardesc);
        }

       


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _StarDescRepository.Dispose();
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
