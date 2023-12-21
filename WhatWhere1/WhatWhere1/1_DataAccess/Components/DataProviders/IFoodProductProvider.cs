using WhatWhere.Data.Entities;

namespace WhatWhere.Components.DataProviders;

public interface IFoodProductProvider
{
    List<FoodProduct> OrderByNameDescending();

    List<FoodProduct> OrderByCountDescending();

    List<FoodProduct> OrderByLocation();

    List<FoodProduct> SelectByLocationFridge();
}