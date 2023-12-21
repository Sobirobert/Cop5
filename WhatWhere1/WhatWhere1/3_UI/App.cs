using WhatWhere.Services;

namespace WhatWhere1._UI;

public class App : IApp
{
    private readonly IEventHandlerServices _eventHandlerService;
    private readonly IUserCommunication _userCommunication;

    public App(IEventHandlerServices eventHandlerService, IUserCommunication userCommunication)
    {
        _eventHandlerService = eventHandlerService;
        _userCommunication = userCommunication;
    }

    public void Run()
    {
        _eventHandlerService.SubscribeToEvents();
        _userCommunication.Menu();
    }
}