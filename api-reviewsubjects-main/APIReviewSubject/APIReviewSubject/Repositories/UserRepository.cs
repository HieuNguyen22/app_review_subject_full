using APIReviewSubject.Data;
using APIReviewSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReviewSubject.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(EntityContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public User CheckLogin(Login userLogin)
        {
            User user = null;
            user = GetAllEntity().FirstOrDefault(a => a.userName.ToLower().Equals(userLogin.userName) && a.password.Equals(userLogin.password));
            return user;
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
        /// Update Point
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pointFix"></param>
        public void UpdatePoint(int id, int pointFix)
        {
            User user = GetEntityById(id);
            user.point += pointFix;
            UpdateEntity(id, user);
        }

        /// <summary>
        /// Get Top Users Who have highest point
        /// </summary>
        /// <returns></returns>
        public List<User> GetTopUser()
        {
            List<User> userList = GetAllEntity().Where(u => u.status == 1).OrderBy(u => u.point).Reverse().ToList();
            return (userList.Count() < 10) ? userList : userList.GetRange(0, 10);
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Disable(int id)
        {
            User user = GetEntityById(id);
            user.status = 2;
            return UpdateEntity(id, user);
        }

        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Enable(int id)
        {
            User user = GetEntityById(id);
            user.status = 1;
            return UpdateEntity(id, user);
        }

        /// <summary>
        /// Get By University
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public List<User> GetByUniversityId(int universityId)
        {
            return Model.Where(u => u.universityId == universityId).ToList();
        }

        /// <summary>
        /// Get By Faculty Id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns></returns>
        public List<User> GetByFacultyId(int facultyId)
        {
            return Model.Where(u => u.facultyId == facultyId).ToList();
        }

        /// <summary>
        /// Get By KeySearch
        /// </summary>
        /// <param name="keySearch"></param>
        /// <returns></returns>
        public List<User> GetByKeySearch(string keySearch)
        {
            return Model.Where(u => u.fullname.ToLower().Contains(keySearch.ToLower())).ToList();
        }
    }
}
