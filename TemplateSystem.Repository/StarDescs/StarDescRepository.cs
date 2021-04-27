using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using TemplateSystem.Entity.Models;
using TemplateSystem.Data.Models;

namespace TemplateSystem.Repository.StarDescs
{
    public class StarDescRepository : IStarDescRepository, IDisposable
    {

        private StarSystemContext _context;

        /// <summary>
        ///     Create a new instance of <see cref="StarDescRepository" />.
        /// </summary>
        /// <param name="transaction">Active transaction</param>
        /// <exception cref="ArgumentNullException">transaction</exception>
        public StarDescRepository()
        {
            _context = new StarSystemContext();

        }

        
        public async Task<List<StarDesc>> GetStarDescsAsync()
        {
            return await _context.StarDescs.ToListAsync();
        }

        public async Task<StarDesc> GetStarDescByIdAsync(int? id)
        {
            return await _context.StarDescs.FindAsync(id);
        }

        public  async Task CreateStarAsync(StarDesc stardesc)
        {
             _context.StarDescs.Add(stardesc);
            await _context.SaveChangesAsync(); 
        }

        public async Task EditStarDescAsync(StarDesc stardesc)
        {
            _context.Entry(stardesc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStarAsync(int? id)
        {
            StarDesc stardesc = await _context.StarDescs.FindAsync(id);
            _context.StarDescs.Remove(stardesc);
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


        #endregion
    }
}