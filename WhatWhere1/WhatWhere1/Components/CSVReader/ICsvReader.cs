using WhatWhere.Components.CSVReader.Models;

namespace WhatWhere.Components.CSVReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacture> ProcessManufacturesrs(string filePath);
}