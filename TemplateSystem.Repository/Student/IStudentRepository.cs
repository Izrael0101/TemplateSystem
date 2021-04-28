using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Repository
{
    /// <summary>
    ///     Repository definition for <c>Student</c>.
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
    public interface IStudentRepository: IDisposable
    {
        Task<List<Student>> GetStudentAsync();
        Task<Student> GetStudentByIdAsync(int? id);
        Task CreateStarAsync(Student stardesc);
        Task DeleteStarAsync(int? id);
        Task EditStudentAsync(Student stardesc);
    }
}