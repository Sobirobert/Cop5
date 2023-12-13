using WhatWhere.Components.DataProviders;
using WhatWhere.Components.CSVReader;
using WhatWhere.Components.XmlReader;
using WhatWhere.Services;
using WhatWhere.Data;
using Microsoft.EntityFrameworkCore;
using WhatWhere.Data.Entities;
using WhatWhere.Components.CSVReader.Models;

namespace WhatWhere;

public class App : IApp
{
    private readonly IEventHandlerServices _eventHandlerService;
    private readonly IUserCommunication _userCommunication;

    private readonly ICsvReader _csvReader;
    private readonly WhatWhereDbContext _dbContext;

    public App(ICsvReader csvReader, WhatWhereDbContext dbContext, IEventHandlerServices eventHandlerService, IUserCommunication userCommunication)
    {
        _eventHandlerService = eventHandlerService;
        _userCommunication = userCommunication;
        _csvReader = csvReader;
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        _eventHandlerService.SubscribeToEvents();
        _userCommunication.Menu();
        // _xmlCreator.CreateXml();
        //_xmlCreator.CreateXmlJoined();
        //_xmlCreator.QueryXml();
        // _datProvider.GenerateDataFromCsvFile();

        //var cars = _csvReader.ProcessCars("D:\\repos3\\Cop5\\WhatWhere1\\WhatWhere1\\Resources\\Files\\fuel.csv");
       // var manufacturers = _csvReader.ProcessManufacturesrs("D:\\repos3\\Cop5\\WhatWhere1\\WhatWhere1\\Resources\\Files\\manufacturers.csv");

        //var cayman = this.ReadFirst("Cayman");
        //_dbContext.Cars.Remove(cayman);                 //usuwanie danych
        //_dbContext.SaveChanges();

        //var cayman = this.ReadFirst("Cayman");
        //cayman.Name = "Mój Samochód";           Zmiana na danych
        //_dbContext.SaveChanges();

       // ReadGroupedCarsFromDb(); //działania na danych

        // InsertData(); //wprowadzanie danych

        // ReadAllCarsFromDb(); //odczyt danych
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
    private void ReadAllCarsFromDb()
    {
        var carsFromDb = _dbContext.Cars.ToList();

        foreach (var carFromDb in carsFromDb)
        {
            Console.WriteLine($"\t{carFromDb.Name}: {carFromDb.Combined}");
        }
    }

    private void InsertData()
    {
        var cars = _csvReader.ProcessCars("D:\\repos2\\repos2\\MotoApp1\\MotoApp1\\Resources\\Files\\fuel.csv");

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
}