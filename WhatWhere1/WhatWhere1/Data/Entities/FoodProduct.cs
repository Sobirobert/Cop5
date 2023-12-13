namespace WhatWhere.Data.Entities;

public class FoodProduct : EntityBase
{
    public FoodProduct(string? name, string? location, int count, DateTime DateChanges)
    {
        Name = name;
        Location = location;
        Count = count;
        DateChange = DateChanges;
    }

    public FoodProduct()
    {
    }

    public string? Name { get; set; }
    public string? Location { get; set; }
    public int Count { get; set; }
    public DateTime DateChange { get; set; }

    public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location {Location}, DateTime - {DateChange} - (Groceries)";
}