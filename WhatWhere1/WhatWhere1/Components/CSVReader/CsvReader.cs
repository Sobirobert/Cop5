using WhatWhere.Components.CSVReader.Extensions;
using WhatWhere.Components.CSVReader.Models;

namespace WhatWhere.Components.CSVReader;

public class CsvReader : ICsvReader
{
    List<Car> ICsvReader.ProcessCars(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Car>();
        }
        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToCar();
        return cars.ToList();
    }

    List<Manufacture> ICsvReader.ProcessManufacturesrs(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacture>();
        }

        var manufactures = File.ReadAllLines(filePath)
            .Where(x => x.Length > 1)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Manufacture()
                {
                    Name = columns[0],
                    Country = columns[1],
                    Year = int.Parse(columns[2])
                };
            });

        return manufactures.ToList();
    }


    ///////


    //var cars = _csvReader.ProcessCars("D:\\repos2\\repos2\\MotoApp\\MotoApp\\Resources\\Files\\fuel.csv");
    //var manufacturers = _csvReader.ProcessManufacturesrs("D:\\repos2\\repos2\\MotoApp\\MotoApp\\Resources\\Files\\manufacturers.csv");

    //var groups = cars.GroupBy(x => x.Manufacturer)
    //    .Select(g=> new 
    //    { 
    //        Name = g.Key,
    //        Max = g.Max(c => c.Combined),
    //        Average = g.Average(c => c.Combined)
    //    })
    //    .OrderBy(x => x.Average);                                    //łączysz dwa pliki przy pomocy GroupBy

    //foreach (var group in groups)
    //{
    //    Console.WriteLine($"{group.Name}");
    //    Console.WriteLine($"{group.Max}");
    //    Console.WriteLine($"{group.Average}");

    ///////////


    //}
    //var carsInCountry = cars.Join(
    //    manufacturers,
    //    c => new { c.Manufacturer, c.Year},
    //    m => new { Manufacturer = m.Name, m.Year },
    //    (car, manufacturers) =>
    //    new
    //    {                                                        // łączysz dwa pliki przy pomocy Join 
    //        manufacturers.Country,
    //        car.Name,
    //        car.Combined
    //    }
    //    )
    //    .OrderByDescending(x => x.Combined)
    //    .ThenBy(x => x.Name);

    //foreach (var car in carsInCountry)
    //{
    //    Console.WriteLine($"Country: {car.Country}");
    //    Console.WriteLine($"\t Name: {car.Name}");
    //    Console.WriteLine($"\t Combined: {car.Combined}");
    //}

    ////////////////////



    //var groups = manufacturers.GroupJoin(
    //    cars,
    //    manufacturer => manufacturer.Name,
    //    car => car.Manufacturer,
    //    (m, g) => new
    //    {                                                               //// łączysz dwa pliki przy pomocy GroupJoin  połączenie metod Join i GroupBy
    //        Manufacturer = m,
    //        Cars = g
    //    })
    //    .OrderBy(x => x.Manufacturer.Name);

    //foreach (var group in groups)
    //{
    //    Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
    //    Console.WriteLine($"\t Cars: {group.Cars.Count()}");
    //    Console.WriteLine($"\t Combined: {group.Cars.Max(x => x.Combined)}");
    //    Console.WriteLine($"\t Combined: {group.Cars.Min(x => x.Combined)}");
    //    Console.WriteLine($"\t Combined: {group.Cars.Average(x => x.Combined)}");
    //}
}