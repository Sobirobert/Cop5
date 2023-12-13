using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;

namespace WhatWhere.Services;

public class EventHandlerServices : IEventHandlerServices
{
    private readonly IRepository<AGD> _agdRepository;
    private readonly IRepository<FoodProduct> _foodProductRepository;
    private readonly IRepository<KitchenAccessory> _kitchenAccessoryRepository;

    public EventHandlerServices(IRepository<AGD> agdRepository, IRepository<FoodProduct> foodProductRepository, IRepository<KitchenAccessory> kitchenAccessoryRepository)
    {
        _agdRepository = agdRepository;
        _foodProductRepository = foodProductRepository;
        _kitchenAccessoryRepository = kitchenAccessoryRepository;
    }

    public void SubscribeToEvents()
    {
        _agdRepository.ItemAdded += ThingAGDRepositoryOnItemAdded;
        _foodProductRepository.ItemAdded += ThingGroceriesRepositoryOnItemAdded;
        _kitchenAccessoryRepository.ItemAdded += ThingKitchenAccessoriesRepositoryOnItemAdded;
        _agdRepository.ItemRemoved += ThingAGDRepositoryOnItemRemove;
        _foodProductRepository.ItemRemoved += ThingGroceriesRepositoryOnItemRemove;
        _kitchenAccessoryRepository.ItemRemoved += ThingKitchenAccessoriesRepositoryOnItemRemove;
    }

    public void ThingAddedAGD(AGD item)
    {
        Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
    }

    public void ThingAddedGroceries(FoodProduct item)
    {
        Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
    }

    public void ThingAddedKitchenAccessories(KitchenAccessory item)
    {
        Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
    }

    public void ThingAGDRepositoryOnItemAdded(object? sender, AGD e)
    {
        Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingGroceriesRepositoryOnItemAdded(object? sender, FoodProduct e)
    {
        Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingKitchenAccessoriesRepositoryOnItemAdded(object? sender, KitchenAccessory e)
    {
        Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingAGDRepositoryOnItemRemove(object? sender, AGD e)
    {
        Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingGroceriesRepositoryOnItemRemove(object? sender, FoodProduct e)
    {
        Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingKitchenAccessoriesRepositoryOnItemRemove(object? sender, KitchenAccessory e)
    {
        Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
    }
}