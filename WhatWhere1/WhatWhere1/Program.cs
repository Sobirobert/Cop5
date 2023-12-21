using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhatWhere.Components.CSVReader;
using WhatWhere.Components.DataProviders;
using WhatWhere.Components.XmlReader;
using WhatWhere.Data;
using WhatWhere.Data.Entities;
using WhatWhere.Data.Repositories;
using WhatWhere.Services;
using WhatWhere1._UI;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<AGD>, SqlRepository<AGD>>();
services.AddSingleton<IRepository<FoodProduct>, SqlRepository<FoodProduct>>();
services.AddSingleton<IRepository<KitchenAccessory>, SqlRepository<KitchenAccessory>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerServices, EventHandlerServices>();
services.AddSingleton<IAdditionalOption, AdditionalOption>();
services.AddSingleton<IFoodProductProvider, FoodProductProvider>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlCreator, XmlCreator>();
services.AddSingleton<IDataProvider, DataProvider>();

services.AddDbContext<WhatWhereDbContext>(options => options
.UseSqlServer("Data Source=DESKTOP-7S5NEGF\\SQLEXPRESS;Initial Catalog=WhatWhereServer;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();