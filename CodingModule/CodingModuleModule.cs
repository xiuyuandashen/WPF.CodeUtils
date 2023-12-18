using CodingModule.ViewModels;
using CodingModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CodingModule
{
    public class CodingModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CodingView, CodingViewViewModel>("Coding");
            //containerRegistry.RegisterForNavigation<UnicodeCoding, UnicodeViewModel>("UnicodeCoding");
            //containerRegistry.RegisterForNavigation<UrlCoding, UrlCodingViewModel>("UrlCoding");
        }
    }
}