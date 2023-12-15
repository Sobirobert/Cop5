using WhatWhere.Data.Entities;

namespace WhatWhere.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T? GetById(int id);

        IEnumerable<T> Read();

        int GetListCount();
    }
}