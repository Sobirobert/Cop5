using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;

namespace WhatWhere.Services;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<AGD> _agdRepositoryToJSON;
    private readonly IRepository<FoodProduct> _foodProductRepositoryToJSON;
    private readonly IRepository<KitchenAccessory> _kitchenAccessoryRepositoryToJSON;
    private readonly IAdditionalOption _additionalOption;

    public UserCommunication(IRepository<AGD> agdRepositoryToJSON, IRepository<FoodProduct> groceriesRepositoryToJSON, IRepository<KitchenAccessory> KitchenAccessoriesRepositoryToJSON,
        IAdditionalOption additionalOption)
    {
        _agdRepositoryToJSON = agdRepositoryToJSON;
        _foodProductRepositoryToJSON = groceriesRepositoryToJSON;
        _kitchenAccessoryRepositoryToJSON = KitchenAccessoriesRepositoryToJSON;
        _additionalOption = additionalOption;
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("Hello User.\n" +
                "Choose option\n" +
                "Press 1 to Add new object\n" +
                "Press 2 to show all products from file\n" +
                "Press 3 to find product by ID\n" +
                "Press 4 to clear products from file by ID\n" +
                "Press 5 to use additional option\n" +
                "To exit insert 'x'\n");
            var userInPut = Console.ReadLine();

            switch (userInPut)
            {
                case "1":
                    var inPut = GetInputFromUserAndReturnInt("\n Which Entities do you want to add ? \n Press: \n 1 - AGD,\n 2 - Groceries,\n 3 - KitchenAccessories.\n");
                    if (inPut == 1)
                    {
                        AddNewAGD(_agdRepositoryToJSON);
                        Console.WriteLine($"Success");
                    }
                    else if (inPut == 2)
                    {
                        AddNewGroceries(_foodProductRepositoryToJSON);
                        Console.WriteLine("Success");
                    }
                    else if (inPut == 3)
                    {
                        AddNewKitchenAccessories(_kitchenAccessoryRepositoryToJSON);
                        Console.WriteLine("Success");
                    }
                    break;

                case "2":
                    WriteAllToConsole(_agdRepositoryToJSON);
                    WriteAllToConsole(_foodProductRepositoryToJSON);
                    WriteAllToConsole(_kitchenAccessoryRepositoryToJSON);
                    break;

                case "3":
                    var userInPut2 = GetInputFromUserAndReturnInt("\nWhich Entities do you want to find by Id ? \n Press 1 - AGD, 2 - Groceries, 3 - KitchenAccessories.\n");
                    if (userInPut2 == 1)
                    {
                        FindProductById(_agdRepositoryToJSON);
                        Console.WriteLine($"Success");
                    }
                    else if (userInPut2 == 2)
                    {
                        FindProductById(_foodProductRepositoryToJSON);
                        Console.WriteLine("Success");
                    }
                    else if (userInPut2 == 3)
                    {
                        FindProductById(_kitchenAccessoryRepositoryToJSON);
                        Console.WriteLine("Success");
                    }
                    break;

                case "4":
                    var userInPut3 = GetInputFromUserAndReturnInt("\nWhich Entities do you want remove by Id ? \n Press 1 - AGD, 2 - Groceries, 3 - KitchenAccessories.\n");
                    if (userInPut3 == 1)
                    {
                        RemoveEntity(_agdRepositoryToJSON);
                        Console.WriteLine($"Success");
                    }
                    else if (userInPut3 == 2)
                    {
                        RemoveEntity(_foodProductRepositoryToJSON);
                        Console.WriteLine("Success");
                    }
                    else if (userInPut3 == 3)
                    {
                        RemoveEntity(_kitchenAccessoryRepositoryToJSON);
                        Console.WriteLine("Success");
                    }
                    break;

                case "5":
                    _additionalOption.Menu();
                    break;

                case "x":
                case "X":
                    CloseAppSaveChanges(_agdRepositoryToJSON, _foodProductRepositoryToJSON, _kitchenAccessoryRepositoryToJSON);
                    return;

                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
    }

    private bool CloseAppSaveChanges(IRepository<AGD> agdRepository, IRepository<FoodProduct> foodProductRepository, IRepository<KitchenAccessory> kitchenAccessoryRepository)
    {
        while (true)
        {
            var choice = GetInputFromUserAndReturnString("Do you want to save changes?\nPress Y if YES\t\tPress N if NO").ToUpper();
            if (choice == "Y")
            {
                agdRepository.Save();
                foodProductRepository.Save();
                kitchenAccessoryRepository.Save();
                Console.WriteLine("Changes saved.");
                return true;
            }
            else if (choice == "N")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please choose Yes or No:");
            }
        }
    }

    private void RemoveEntity<T>(IRepository<T> repository) where T : class, IEntity
    {
        var entityFound = FindProductById(repository);
        if (entityFound != null)
        {
            while (true)
            {
                Console.WriteLine($"Do you really want to remove this {typeof(T).Name}?");
                var choice = GetInputFromUserAndReturnString("Press Y if YES\t\tPress N if NO").ToUpper();
                if (choice == "Y")
                {
                    repository.Remove(entityFound);
                    Console.WriteLine($"Your object name:{typeof(T).Name} remove. ");
                    break;
                }
                else if (choice == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose Yes or No:");
                }
            }
        }
    }

    private T? FindProductById<T>(IRepository<T> entityRepository) where T : class, IEntity
    {
        while (true)
        {
            var choiceID = GetInputFromUserAndReturnInt($"Enter the ID of the {typeof(T).Name} you want to find:");

            var entity = entityRepository.GetById(choiceID);
            if (entity != null)
            {
                Console.WriteLine(entity.ToString());
            }
            return entity;
        }
    }

    private void AddNewAGD(IRepository<AGD> agdRepositoryToJSON)
    {
        Console.WriteLine("Insert name");
        var name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        var newObjcet = new AGD
        {
            Name = name,
            Location = location,
            Count = countInt,
            DateChange = DateTime.Now
        };
        agdRepositoryToJSON.Add(newObjcet);
        Console.WriteLine($"AGD Added: {name}");
    }

    private void AddNewKitchenAccessories(IRepository<KitchenAccessory> kitchenAccessoryRepositoryToJSON)
    {
        Console.WriteLine("Insert name");
        var name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        var newObjcet = new KitchenAccessory
        {
            Name = name,
            Location = location,
            Count = countInt,
            DateChange = DateTime.Now
        };
        kitchenAccessoryRepositoryToJSON.Add(newObjcet);
        Console.WriteLine($"KitchenAccessories Added: {name}");
    }

    private void AddNewGroceries(IRepository<FoodProduct> foodProductRepositoryToJSON)
    {
        Console.WriteLine("Insert name");
        var name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        var newObjcet = new FoodProduct
        {
            Name = name,
            Location = location,
            Count = countInt,
            DateChange = DateTime.Now
        };
        foodProductRepositoryToJSON.Add(newObjcet);
        Console.WriteLine($"Groceries Added: {name}");
    }

    private static int GetInputFromUserAndReturnInt(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        var userInPutInt = AddStringConversionToInt(userInput);
        return userInPutInt;
    }

    private static string GetInputFromUserAndReturnString(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        return userInput;
    }

    private static int AddStringConversionToInt(string value)
    {
        if (int.TryParse(value, out int number))
        {
            Console.WriteLine("The conversion success.");
        }
        else
        {
            Console.WriteLine("The conversion wasn't successful.");
        }
        return number;
    }

    private void WriteAllToConsole<T>(IRepository<T> repository) where T : class, IEntity
    {
        Console.WriteLine("\nAll products:\n");
        var items = repository.GetAll();
        if (items.ToList().Count == 0)
        {
            Console.WriteLine("\n No objects in Memory, loading from file:\n");
            items = repository.Read();
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}