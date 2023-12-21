using WhatWhere.Components.DataProviders;

namespace WhatWhere.Services;

public class AdditionalOption : IAdditionalOption
{
    private readonly IFoodProductProvider _foodProductProvider;

    public AdditionalOption(IFoodProductProvider entitiesProviderGroceries)
    {
        _foodProductProvider = entitiesProviderGroceries;
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine(
                "--- WHAT KIND OF INFORMATION YOU WANT TO VIEW ---\n" +
                "1 - Order by name descending\n" +
                "2 - Get Groceries order by count descending\n" +
                "3 - Order by location \n" +
                "4 - Select fridge location fridge\n" +
                "X - Back to MAIN MENU\n");

            var userInput = GetInputFromUserAndReturnString("What you want to do? \n").ToUpper();

            switch (userInput)
            {
                case "1":
                    OrderByNameDescending();
                    break;

                case "2":
                    SelectLowCountProducts();
                    break;

                case "3":
                    OrderByLocation();
                    break;

                case "4":
                    SelectByLocationFridge();
                    break;

                case "X":
                    return;

                default:
                    Console.WriteLine("Invalid operation.\n");
                    continue;
            }
        }
    }

    private void SelectByLocationFridge()
    {
        var names = _foodProductProvider.SelectByLocationFridge();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void OrderByLocation()
    {
        var names = _foodProductProvider.OrderByLocation();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void OrderByNameDescending()
    {
        var names = _foodProductProvider.OrderByNameDescending();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void SelectLowCountProducts()
    {
        var names = _foodProductProvider.OrderByCountDescending();
        foreach (var name in names)
        {
            Console.WriteLine($" Your min count product is: {name}");
        }
    }

    private static string GetInputFromUserAndReturnString(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        return userInput;
    }
}