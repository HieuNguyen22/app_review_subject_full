using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class AdminRepository : BaseRepository<Admin>
    {
        public AdminRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Admin CheckLogin(Login login)
        {
            Admin admin = null;
            admin = GetAllEntity().FirstOrDefault(a => a.userName.ToLower().Equals(login.userName) && a.password.Equals(login.password));
            return admin;
        }

        /// <summary>
        /// Check Account Exist
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckAccountExist(string userName)
        {
            var arr = Model.Where(u => u.userName.ToLower() == userName.ToLower());
            if (arr.Any()) { return true; }
            return false;
        }

        /// <summary>
        /// Get By Key Search
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        public List<Admin> GetByKeySearch(string keySearch)
        {
            return Model.Where(c => c.userName.ToLower().Contains(keySearch.ToLower())).ToList();
        }
    }
}
