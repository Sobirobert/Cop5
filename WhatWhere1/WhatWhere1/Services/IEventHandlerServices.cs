using WhatWhere.Data.Entities;

namespace WhatWhere.Services
{
    public interface IEventHandlerServices
    {
        void ThingAddedAGD(AGD item);

        void ThingAddedGroceries(FoodProduct item);

        void ThingAddedKitchenAccessories(KitchenAccessory item);

        void ThingAGDRepositoryOnItemAdded(object? sender, AGD e);

        void ThingGroceriesRepositoryOnItemAdded(object? sender, FoodProduct e);

        void ThingKitchenAccessoriesRepositoryOnItemAdded(object? sender, KitchenAccessory e);

        void ThingAGDRepositoryOnItemRemove(object? sender, AGD e);

        void ThingGroceriesRepositoryOnItemRemove(object? sender, FoodProduct e);

        void ThingKitchenAccessoriesRepositoryOnItemRemove(object? sender, KitchenAccessory e);

        void SubscribeToEvents();
    }
}