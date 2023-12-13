using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;

namespace WhatWhere.Components.DataProviders;

public class FoodProductProvider : IFoodProductProvider
{
    private readonly IRepository<FoodProduct> _foodProductProvider;

    public FoodProductProvider(IRepository<FoodProduct> foodProductProvider)
    {
        _foodProductProvider = foodProductProvider;
    }

    public List<FoodProduct> OrderByNameDescending()
    {
        var entitys = _foodProductProvider.GetAll();
        return entitys.OrderByDescending(x => x.Name).ToList();
    }

    public List<FoodProduct> OrderByCountDescending()
    {
        var entitys = _foodProductProvider.GetAll();
        return entitys.OrderByDescending(x => x.Count).ToList();
    }

    public List<FoodProduct> OrderByLocation()
    {
        var entitys = _foodProductProvider.GetAll();
        return entitys.OrderByDescending(x => x.Location).ToList();
    }

    public List<FoodProduct> SelectByLocationFridge()
    {
        var entitys = _foodProductProvider.GetAll();
        return entitys.Where(x => x.Location == "Fridge").ToList();
    }

    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.OrderBy(x => x.Name).ToList();
    //}

    //public List<Groceries> SelectLowCountProducts()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.OrderByDescending(x => x.Count).ToList();
    //}

    //public List<string> GetUniqueEntitiesByName()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Select(c => c.Location).Distinct().ToList();
    //}

    //public int SelectByCountSortByMin()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Select(x => x.Count).Max();
    //}

    //public List<Groceries> GetSpecificColumns()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    var list = entitys.Select(entity => new Groceries
    //    {
    //        Id = entity.Id,
    //        Name = entity.Name,
    //        Location = entity.Location
    //    }).ToList();
    //    return list;
    //}

    //public string AnonymousClass()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    var list = entitys.Select(entity => new
    //    {
    //        Identifier = entity.Id,
    //        ProductName = entity.Name,
    //        ProductLocation = entity.Location
    //    });

    //    StringBuilder sb = new(2048);

    //    foreach (var entity in list)
    //    {
    //        sb.AppendLine($"Product ID: {entity.Identifier}");
    //        sb.AppendLine($"Product Name: {entity.ProductName}");
    //        sb.AppendLine($"Product Location: {entity.ProductLocation}");
    //    }
    //    return sb.ToString();
    //}

    //public List<Groceries> OrderByNameDescending()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.OrderByDescending(x => x.Name).ToList();
    //}

    //public List<Groceries> OrderByCountAndName()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.OrderBy(x => x.Count)
    //        .ThenBy(x => x.Name)
    //        .ToList();
    //}

    //public List<Groceries> OrderByCountAndNameDesc()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.OrderByDescending(x => x.Count)
    //        .ThenByDescending(x => x.Name)
    //        .ToList();
    //}

    //public List<Groceries> WhereStartsWith(string prefix)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Where(x => x.Name.StartsWith(prefix)).ToList();
    //}

    //public List<Groceries> WhereStartsWithAndCountIsGreaterThan(string prefix, decimal count)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Where(x => x.Name.StartsWith(prefix) && x.Count > count).ToList();
    //}

    //public List<Groceries> WhereColorIs(string location)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.ByLocation(location).ToList();
    //}

    //public Groceries FirstByLocation(string location)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.First(x => x.Location == location);
    //}

    //public Groceries? FirstOrDefaultByLocation(string location)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.FirstOrDefault(x => x.Location == location);
    //}

    //public Groceries FirstOrDefaultByLocationWithDefault(string location)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //        .FirstOrDefault(
    //        x => x.Location == location,
    //        new Groceries { Id = -1, Name = "Not found" });
    //}

    //public Groceries LastByCount(int count)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Last(x => x.Count == count);
    //}

    //public Groceries SingleById(int id)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Single(x => x.Id == id);
    //}

    //public Groceries SingleOrDefaultById(int id)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.SingleOrDefault(x => x.Id == id);
    //}

    //public List<Groceries> TakeGroceries(int howMany)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //        .OrderBy(x => x.Name)
    //        .Take(howMany)
    //        .ToList();
    //}

    //public List<Groceries> TakeGroceries(Range range)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //        .OrderBy(x => x.Name)
    //        .Take(range)
    //        .ToList();
    //}

    //public List<Groceries> TakeCarsWhileNameStartsWith(string prefix)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //       .OrderBy(x => x.Name)
    //       .TakeWhile(x => x.Name.StartsWith(prefix))
    //       .ToList();
    //}

    //public List<Groceries> SkipGroceries(int howMany)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //       .OrderBy(x => x.Name)
    //       .Skip(howMany)
    //       .ToList();
    //}

    //public List<Groceries> SkipGroceriesWhileNameStartsWit(string prefix)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //      .OrderBy(x => x.Name)
    //      .SkipWhile(x => x.Name.StartsWith(prefix))
    //      .ToList();
    //}

    //public List<string> DistinctAllLocation()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //        .Select(x => x.Location)
    //        .Distinct()
    //        .OrderBy(c => c)
    //        .ToList();
    //}

    //public List<Groceries> DistinctByLocation()
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys
    //        .DistinctBy(x => x.Location)
    //        .OrderBy(x => x.Count)
    //        .ToList();
    //}

    //public List<Groceries[]> ChunkGroceries(int size)
    //{
    //    var entitys = _foodProductProvider.GetAll();
    //    return entitys.Chunk(size).ToList();
    //}
}