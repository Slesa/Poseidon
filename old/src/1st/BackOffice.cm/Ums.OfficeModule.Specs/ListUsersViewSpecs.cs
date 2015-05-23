using System.Windows;
using Machine.Specifications;
using Ums.OfficeModule.Views;

namespace Ums.OfficeModule.Specs
{
    //[Subject(typeof(ListUsersView)), Ignore("Can't test wpf app yet")]
    public class When_instancing_list_users_view_model
    {
        Because of = () =>
            {
                _mainWindow = new Window();
                _listView = new ListUsersView();
                _mainWindow.Content = _listView;
            };

        It should_work = () =>
            {
                var app = new Application();
                app.Run(_mainWindow);
            };
        static ListUsersView _listView;
        static Window _mainWindow;
    }
}
