
using WhatWhere.Services;
using WhatWhere1.Components.SqlReader;

namespace WhatWhere;

public class App : IApp
{
    private readonly IEventHandlerServices _eventHandlerService;
    private readonly IUserCommunication _userCommunication;
    private readonly ISqlReader _sqlReader;

    public App( IEventHandlerServices eventHandlerService, IUserCommunication userCommunication, ISqlReader sqlReader)
    {
        _eventHandlerService = eventHandlerService;
        _userCommunication = userCommunication;
        _sqlReader = sqlReader;
    }

    public void Run()
    {
        _eventHandlerService.SubscribeToEvents();
        _userCommunication.Menu();
       // _sqlReader.InsertData();
    }
}