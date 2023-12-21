namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Data.Entities;

public class WhatWhereDbContext : DbContext
{
    public WhatWhereDbContext(DbContextOptions<WhatWhereDbContext> options)
        : base(options)
    {
    }

    public DbSet<AGD> AGDs { get; set; }
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<KitchenAccessory> KitchenAccessories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine);
}