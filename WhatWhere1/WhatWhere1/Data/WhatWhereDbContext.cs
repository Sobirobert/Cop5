namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Data.Entities;

public class WhatWhereDbContext : DbContext
{
    public DbSet<AGD> AGDs => Set<AGD>();
    public DbSet<FoodProduct> FoodProducts => Set<FoodProduct>();
    public DbSet<KitchenAccessory> KitchenAccessories => Set<KitchenAccessory>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}