using WhatWhere.Data.Entities;

namespace WhatWhere.Components.DataProviders.Extensions;

public static class EntitiesHelper
{
    public static IEnumerable<FoodProduct> ByLocation(this IEnumerable<FoodProduct> query, string location)
    {
        return query.Where(x => x.Location == location);
    }
}