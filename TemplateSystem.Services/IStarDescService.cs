using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Services
{
    public interface IStarDescService : IDisposable
    {
        Task<List<StarDesc>> GetAllStarsAsync();
        Task<StarDesc> GetStarDescriptionByIdAsync(int? id);
        Task AddStarAsync(StarDesc stardesc);
        Task DeleteStarAsync(int? id);
        Task EditStarDescAsync(StarDesc stardesc);

    }
}