using WhatWhere1.Components.CsvReader.Models;

namespace WhatWhere1.Components.CsvReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacture> ProcessManufacturesrs(string filePath);
}