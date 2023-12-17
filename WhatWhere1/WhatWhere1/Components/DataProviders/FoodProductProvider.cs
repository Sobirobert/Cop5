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
}