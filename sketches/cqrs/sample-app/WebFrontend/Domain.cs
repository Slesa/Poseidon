﻿using Cafe.Infrastructure;
using Edument.CQRS;
using CafeReadModels;
using Cafe.Tab;

namespace WebFrontend
{
    public static class Domain
    {
        public static MessageDispatcher Dispatcher;
        public static IOpenTabQueries OpenTabQueries;
        public static IChefTodoListQueries ChefTodoListQueries;

        public static void Setup()
        {
            Dispatcher = new MessageDispatcher(new InMemoryEventStore());
            
            Dispatcher.ScanInstance(new TabCommandHandlers());

            OpenTabQueries = new OpenTabs();
            Dispatcher.ScanInstance(OpenTabQueries);

            ChefTodoListQueries = new ChefTodoList();
            Dispatcher.ScanInstance(ChefTodoListQueries);
        }
    }
}