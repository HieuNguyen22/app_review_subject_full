using APIReviewSubject.Models;
using System.Collections.Generic;

namespace APIReviewSubject.Repositories
{
    public interface IRepository<T>
    {
        BaseEntity CreateEntity(BaseEntity baseEntity);
        List<T> GetAllEntity();
        T GetEntityById(int id);
        bool UpdateEntity(int id, BaseEntity baseEntity);
        bool DeleteEntityById(int id);
    }
}
