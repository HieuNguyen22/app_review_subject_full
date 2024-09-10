using APIReviewSubject.Data;
using APIReviewSubject.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class UniversityRepository : BaseRepository<University>
    {
        public UniversityRepository(EntityContext ctx) : base(ctx)
        {
        }
       
        /// <summary>
        /// get list university by key search
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        public List<University> GetByKeySearch(string keySearch)
        {
            return Model.Where(u => u.name.ToLower().Contains(keySearch.ToLower()))
                .OrderBy(u => u.name).ToList();
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            University university = GetEntityById(id);
            university.status = 2;
            return UpdateEntity(id, university);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            University university = GetEntityById(id);
            university.status = 1;
            return UpdateEntity(id, university);
        }
    }
}
