using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;

namespace Winemonk.Wpf.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Type> mainViews = assembly.GetTypes()
                .Where(t => t.IsClass && t.Namespace == "Winemonk.Wpf.Sample.Views.MainViews")
                .ToList();
            mainViews.ForEach(t => containerRegistry.RegisterForNavigation(t, t.Name));
        }
    }
}
