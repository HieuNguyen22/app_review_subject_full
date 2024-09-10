using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using APIReviewSubject.Models;
using APIReviewSubject.Data;

namespace APIReviewSubject.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly EntityContext _context;
        protected DbSet<T> Model { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(EntityContext context)
        {
            this._context = context;
            this.Model = context.Set<T>();
        }

        /// <summary>
        /// Create Entity
        /// </summary>
        /// <param name="baseEntity"></param>
        /// <returns></returns>
        public BaseEntity CreateEntity(BaseEntity baseEntity)
        {
            T entity = baseEntity as T;
            Model.Add(entity);
            SaveChange();
            return baseEntity;
        }

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllEntity()
        {
            return Model.ToList();
        }

        /// <summary>
        /// Get Entity By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityById(int id)
        {
            T entity;
            try
            {
                entity = Model.Find(id);
            }
            catch
            {
                entity = null;
            }
            return entity;
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="baseEntity"></param>
        /// <returns></returns>
        public bool UpdateEntity(int id, BaseEntity baseEntity)
        {
            try
            {
                baseEntity.id = id;
                _context.Entry(baseEntity).State = EntityState.Modified;
                SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Entity By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEntityById(int id)
        {
            bool result = false;
            if (EntityExist(id))
            {
                T entity = GetEntityById(id);
                try
                {
                    Model.Remove(entity);
                    SaveChange();
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Context save changes
        /// </summary>
        public void SaveChange()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Check Entity Exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EntityExist(int id)
        {
            if (Model.Find(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
