
using WhatWhere.Components.CSVReader.Models;

namespace WhatWhere1.Components.SqlReader;

public interface ISqlReader 
{ 
    void InsertData();
    void ReadAllCarsFromDb();
    void ReadGroupedCarsFromDb();
    void DeleteDataFromDb(string name);
    void ChangeDataFromDb(string name);
    Car? ReadFirst(string name);
}
