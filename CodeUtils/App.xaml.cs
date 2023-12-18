using CodeUtils.Config;
using CodeUtils.Views;
using CodingModule;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace CodeUtils
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            // 初始化menu 并导航到一个页面
            IStartService startService = App.Current.MainWindow.DataContext as IStartService;
            startService.Start();
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // 添加Coding模块
            moduleCatalog.AddModule<CodingModuleModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
