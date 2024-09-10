using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class FacultyRepository : BaseRepository<Faculty>
    {
        public FacultyRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Get list Faculty by Page
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public List<Faculty> GetByUniversityId(int universityId)
        {
            return Model.Where(f => f.universityId == universityId).OrderBy(f => f.name).ToList();
        }

        /// <summary>
        /// Get By Key Search
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        public List<Faculty> GetByKeySearch(string keySearch)
        {
            return Model.Where(c => c.name.ToLower().Contains(keySearch.ToLower())).ToList();
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            Faculty faculty = GetEntityById(id);
            faculty.status = 2;
            return UpdateEntity(id, faculty);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            Faculty faculty = GetEntityById(id);
            faculty.status = 1;
            return UpdateEntity(id, faculty);
        }
    }
}
