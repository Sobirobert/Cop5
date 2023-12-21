using WhatWhere.Data.Entities;

namespace WhatWhere1.Components.DataProviders;

public interface IFoodProductProvider
{
    List<FoodProduct> OrderByNameDescending();

    List<FoodProduct> OrderByCountDescending();

    List<FoodProduct> OrderByLocation();

    List<FoodProduct> SelectByLocationFridge();
}