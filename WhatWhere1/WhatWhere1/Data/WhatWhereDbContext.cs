namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Components.CSVReader.Models;
using WhatWhere.Data.Entities;

public class WhatWhereDbContext : DbContext
{
    public WhatWhereDbContext(DbContextOptions<WhatWhereDbContext> options)
        : base(options)
    {

    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<AGD> AGDs => Set<AGD>();
    public DbSet<FoodProduct> FoodProducts => Set<FoodProduct>();
    public DbSet<KitchenAccessory> KitchenAccessories => Set<KitchenAccessory>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine);
}