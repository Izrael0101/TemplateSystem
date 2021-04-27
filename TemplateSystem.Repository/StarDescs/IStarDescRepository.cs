using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Repository.StarDescs
{
    /// <summary>
    ///     Repository definition for <c>StarDesc</c>.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This definition do not include any query methods as you should typically only include them
    ///         once they are actually needed. I do recommend that you name them after where they are used to
    ///         make it easier to maintain and remove old queries when the application age.
    ///     </para>
    ///     <para>
    ///         You could for instance name a method <code>GetUsersForIndexPage</code>.
    ///     </para>
    /// </remarks>
    public interface IStarDescRepository: IDisposable
    {
        Task<List<StarDesc>> GetStarDescsAsync();
        Task<StarDesc> GetStarDescByIdAsync(int? id);
        Task CreateStarAsync(StarDesc stardesc);
        Task DeleteStarAsync(int? id);
        Task EditStarDescAsync(StarDesc stardesc);
    }
}