using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;

namespace WhatWhere1.Components.DataProviders;

public class FoodProductProvider : IFoodProductProvider
{
    private readonly IRepository<FoodProduct> _foodProductRepository;

    public FoodProductProvider(IRepository<FoodProduct> foodProductRepository)
    {
        _foodProductRepository = foodProductRepository;
    }

    public List<FoodProduct> OrderByNameDescending()
    {
        var entitys = _foodProductRepository.GetAll();
        return entitys.OrderByDescending(x => x.Name).ToList();
    }

    public List<FoodProduct> OrderByCountDescending()
    {
        var entitys = _foodProductRepository.GetAll();
        return entitys.OrderByDescending(x => x.Count).ToList();
    }

    public List<FoodProduct> OrderByLocation()
    {
        var entitys = _foodProductRepository.GetAll();
        return entitys.OrderByDescending(x => x.Location).ToList();
    }

    public List<FoodProduct> SelectByLocationFridge()
    {
        var entitys = _foodProductRepository.GetAll();
        return entitys.Where(x => x.Location == "Fridge").ToList();
    }
}