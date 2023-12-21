using WhatWhere.Data.Entities;

namespace WhatWhere.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
       where T : class, IEntity
    {
        public event EventHandler<T> ItemAdded;

        public event EventHandler<T> ItemRemoved;
    }
}