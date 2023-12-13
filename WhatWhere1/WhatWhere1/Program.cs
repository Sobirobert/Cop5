using Microsoft.Extensions.DependencyInjection;
using WhatWhere;
using WhatWhere.Components.CSVReader;
using WhatWhere.Components.DataProviders;
using WhatWhere.Components.XmlReader;
using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;
using WhatWhere.Services;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<AGD>, SqlRepository<AGD>>();
services.AddSingleton<IRepository<FoodProduct>, SqlRepository<FoodProduct>>();
services.AddSingleton<IRepository<KitchenAccessory>, SqlRepository<KitchenAccessory>>();
services.AddSingleton<IRepository<AGD>, RepositoryToFileJson<AGD>>();
services.AddSingleton<IRepository<FoodProduct>, RepositoryToFileJson<FoodProduct>>();
services.AddSingleton<IRepository<KitchenAccessory>, RepositoryToFileJson<KitchenAccessory>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerServices, EventHandlerServices>();
services.AddSingleton<IAdditionalOption, AdditionalOption>();
services.AddSingleton<IFoodProductProvider, FoodProductProvider>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlCreator, XmlCreator>();
services.AddSingleton<IDataProvider, DataProvider>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();