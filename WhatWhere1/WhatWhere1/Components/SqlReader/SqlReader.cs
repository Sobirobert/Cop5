using WhatWhere.Components.CSVReader;
using WhatWhere.Components.CSVReader.Models;
using WhatWhere.Data;

namespace WhatWhere1.Components.SqlReader;

public class SqlReader : ISqlReader
{
    private readonly ICsvReader _csvReader;
    private readonly WhatWhereDbContext _dbContext;

    public SqlReader(ICsvReader csvReader, WhatWhereDbContext dbContext)
    {
        _csvReader = csvReader;
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }

    public void CarInfo()
    {
        // InsertData();
    }

    private void ChangeDataFromDb(string name)
    {
        var cayman = this.ReadFirst($"{name}");
        cayman.Name = "Mój Samochód";
        _dbContext.SaveChanges();
    }

    private void DeleteDataFromDb(string name)
    {
        var cayman = this.ReadFirst($"{name}");
        _dbContext.Cars.Remove(cayman);                 //usuwanie danych
        _dbContext.SaveChanges();
    }

    private void InsertData()
    {
        var cars = _csvReader.ProcessCars("D:\\repos3\\Cop5\\WhatWhere1\\WhatWhere1\\Resources\\Files\\fuel.csv");

        foreach (var car in cars)
        {
            _dbContext.Cars.Add(new Car()
            {
                Manufacturer = car.Manufacturer,
                Name = car.Name,
                Year = car.Year,
                City = car.City,
                Combined = car.Combined,
                Cylinders = car.Cylinders,
                Displacement = car.Displacement,
                Highway = car.Highway
            });
            _dbContext.SaveChanges();
        }
    }

    private void ReadAllCarsFromDb()
    {
        var carsFromDb = _dbContext.Cars.ToList();

        foreach (var carFromDb in carsFromDb)
        {
            Console.WriteLine($"\t{carFromDb.Name}: {carFromDb.Combined}");
        }
    }

    private Car? ReadFirst(string name)
    {
        return _dbContext.Cars.FirstOrDefault(x => x.Name == name);
    }

    private void ReadGroupedCarsFromDb()
    {
        var groups = _dbContext
           .Cars
           .GroupBy(x => x.Manufacturer)
           .Select(x => new
           {
               Name = x.Key,
               Cars = x.ToList()
           })
           .ToList();
        foreach (var group in groups)
        {
            Console.WriteLine($"\t{group.Name}");
            Console.WriteLine($"==========");
            foreach (var car in group.Cars)
            {
                Console.WriteLine($"\t{car.Name}: {car.Combined}");
            }
            Console.WriteLine();
        }
    }
}