using System;
using System.Collections.Generic;
using Pms.Business.Contracts;
using Pms.Business.Models;
using Pms.Business.Services;
using Poseidon.Common.Persistence;

namespace FrontEnd.app.cli
{
    class BusinessApp
    {
        IDbConversation DbConversation { get; set; }
        IProvideTerminals TerminalProvider { get; set; }
        IProvideWorkbenches WorkbenchProvider { get; set; }
        IProvideTable TableProvider { get; set; }

        PmsTerminal PmsTerminal { get; set; }
        PmsWorkbench PmsWorkbench { get; set; }

        public BusinessApp()
        {
            //DbConversation = new DbConversation(new HibernateSessionFactory(new SqlServerPersistenceConfiguration(), ));
            TableProvider = new TableProvider();
            WorkbenchProvider = new WorkbenchProvider { DbConversation = DbConversation, TableProvider = TableProvider,};
            TerminalProvider = new TerminalProvider { DbConversation = DbConversation, WorkbenchProvider = WorkbenchProvider,};
        }

        public void Run()
        {
            for (;;)
            {
                if (!CheckTerminal()) continue;
                if (!CheckWorkbench()) continue;

                if (!MainMenu()) break;
            }
        }

        bool CheckTerminal()
        {
            if (PmsTerminal != null) return true;
            var terminalId = new ManualInput("Terminal", 3).GetNumber();
            if (terminalId > 0)
            {
                PmsTerminal = TerminalProvider.ClaimTerminal(terminalId);
            }
            return PmsTerminal != null;
        }

        bool CheckWorkbench()
        {
            if (PmsWorkbench != null) return true;
            var waiterId = new ManualInput("Waiter", 3).GetNumber();
            if (waiterId > 0)
            {
                PmsWorkbench = WorkbenchProvider.ClaimWorkbench(waiterId);
            }
            return PmsWorkbench != null;
        }

        static readonly IEnumerable<string> MainMenuItems = new[]
            {
                "Order", "Void", "Pay", "Change", "Tables", "Split", "Reports"
            };

        bool MainMenu()
        {
            var choice = new MenuInput("Main", MainMenuItems).Select();
            return choice > 0;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var app = new BusinessApp();
            app.Run();
        }
    }
}
