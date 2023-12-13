using WhatWhere.Components.DataProviders;
using WhatWhere.Components.CSVReader;
using WhatWhere.Components.XmlReader;
using WhatWhere.Services;

namespace WhatWhere;

public class App : IApp
{
    private readonly IEventHandlerServices _eventHandlerService;
    private readonly IUserCommunication _userCommunication;

    private readonly IDataProvider _datProvider;
    private readonly IXmlCreator _xmlCreator;

    public App(IEventHandlerServices eventHandlerService, IUserCommunication userCommunication, IXmlCreator xmlCreator, IDataProvider datProvider)
    {
        _eventHandlerService = eventHandlerService;
        _userCommunication = userCommunication;
        _xmlCreator = xmlCreator;
        _datProvider = datProvider;
    }

    public void Run()
    {
        // _eventHandlerService.SubscribeToEvents();
        // _userCommunication.Menu();
        // _xmlCreator.CreateXml();
        //_xmlCreator.CreateXmlJoined();
        //_xmlCreator.QueryXml();
        _datProvider.GenerateDataFromCsvFile();
    }
}