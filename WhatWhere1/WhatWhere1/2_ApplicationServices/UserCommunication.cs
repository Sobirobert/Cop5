using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;

namespace WhatWhere.Services;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<AGD> _agdRepository;
    private readonly IRepository<FoodProduct> _foodProductRepository;
    private readonly IRepository<KitchenAccessory> _kitchenAccessoryRepository;
    private readonly IAdditionalOption _additionalOption;

    public UserCommunication(IRepository<AGD> agdRepository, IRepository<FoodProduct> groceriesRepository, IRepository<KitchenAccessory> KitchenAccessoriesRepository,
        IAdditionalOption additionalOption)
    {
        _agdRepository = agdRepository;
        _foodProductRepository = groceriesRepository;
        _kitchenAccessoryRepository = KitchenAccessoriesRepository;
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
                        AddNewAGD(_agdRepository);
                        Console.WriteLine($"Success");
                    }
                    else if (inPut == 2)
                    {
                        AddNewFoodProduct(_foodProductRepository);
                        Console.WriteLine("Success");
                    }
                    else if (inPut == 3)
                    {
                        AddNewKitchenAccessories(_kitchenAccessoryRepository);
                        Console.WriteLine("Success");
                    }
                    break;

                case "2":
                    WriteAllToConsole(_agdRepository);
                    WriteAllToConsole(_foodProductRepository);
                    WriteAllToConsole(_kitchenAccessoryRepository);
                    break;

                case "3":
                    var userInPut2 = GetInputFromUserAndReturnInt("\nWhich Entities do you want to find by Id ? \n Press 1 - AGD, 2 - Groceries, 3 - KitchenAccessories.\n");
                    if (userInPut2 == 1)
                    {
                        FindProductById(_agdRepository);
                        Console.WriteLine($"Success");
                    }
                    else if (userInPut2 == 2)
                    {
                        FindProductById(_foodProductRepository);
                        Console.WriteLine("Success");
                    }
                    else if (userInPut2 == 3)
                    {
                        FindProductById(_kitchenAccessoryRepository);
                        Console.WriteLine("Success");
                    }
                    break;

                case "4":
                    var userInPut3 = GetInputFromUserAndReturnInt("\nWhich Entities do you want remove by Id ? \n Press 1 - AGD, 2 - Groceries, 3 - KitchenAccessories.\n");
                    if (userInPut3 == 1)
                    {
                        RemoveObjectFromEntitie(_agdRepository);
                        Console.WriteLine($"Success");
                    }
                    else if (userInPut3 == 2)
                    {
                        RemoveObjectFromEntitie(_foodProductRepository);
                        Console.WriteLine("Success");
                    }
                    else if (userInPut3 == 3)
                    {
                        RemoveObjectFromEntitie(_kitchenAccessoryRepository);
                        Console.WriteLine("Success");
                    }
                    break;

                case "5":
                    _additionalOption.Menu();
                    break;

                case "x":
                case "X":
                    return;

                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
    }
        
    private void RemoveObjectFromEntitie<T>(IRepository<T> repository) where T : class, IEntity
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
        var name = GetInputFromUserAndReturnString("Insert name");

        var location = GetInputFromUserAndReturnString("Insert Location");

        var count = GetInputFromUserAndReturnInt("Insert Count");

        agdRepositoryToJSON.Add(new AGD()
        {
            Name = name,
            Location = location,
            Count = count,
            DateChange = DateTime.Now
        });
        Console.WriteLine($"AGD Added: {name}");
    }

    private void AddNewKitchenAccessories(IRepository<KitchenAccessory> kitchenAccessoryRepositoryToJSON)
    {
        var name = GetInputFromUserAndReturnString("Insert name");

        var location = GetInputFromUserAndReturnString("Insert Location");

        var count = GetInputFromUserAndReturnInt("Insert Count");

        kitchenAccessoryRepositoryToJSON.Add(new KitchenAccessory()
        {
            Name = name,
            Location = location,
            Count = count,
            DateChange = DateTime.Now
        });
        Console.WriteLine($"KitchenAccessories Added: {name}");
    }

    private void AddNewFoodProduct(IRepository<FoodProduct> foodProductRepositoryToJSON)
    {
        var name = GetInputFromUserAndReturnString("Insert name");

        var location = GetInputFromUserAndReturnString("Insert Location");

        var count = GetInputFromUserAndReturnInt("Insert Count");

        foodProductRepositoryToJSON.Add(new FoodProduct()
        {
            Name = name,
            Location = location,
            Count = count,
            DateChange = DateTime.Now
        });
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