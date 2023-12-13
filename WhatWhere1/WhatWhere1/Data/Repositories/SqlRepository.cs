namespace WhatWhere.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatWhere.Data;
using WhatWhere.Data.Entities;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly WhatWhereDbContext _dbContext;

    public SqlRepository(WhatWhereDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public event EventHandler<T>? ItemAdded;

    public event EventHandler<T>? ItemRemoved;

    public void Add(T item)
    {
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T GetById(int id) => _dbSet.Find(id);

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }

    public int GetListCount()
    {
        return Read().ToList().Count;
    }
}