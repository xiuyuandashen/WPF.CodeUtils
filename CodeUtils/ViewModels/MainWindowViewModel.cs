using CodeUtils.Config;
using CodeUtils.Model;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

namespace CodeUtils.ViewModels
{
    public class MainWindowViewModel : BindableBase,IStartService
    {

        public void Start()
        {
            CreateMenuBar();
            Navigation(Menus[0]);
        }

        public string MainRegion { get; private set; } = "MainViewRegion";

        private string _title = "工具箱";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool open;

        public bool Open
        {
            get { return open; }
            set { SetProperty(ref open, value); }
        }

        private ObservableCollection<MenuItem> menus;
        private readonly IRegionManager regionManager;

        public ObservableCollection<MenuItem> Menus
        {
            get { return menus; }
            set { SetProperty(ref menus, value); }
        }

        public DelegateCommand<MenuItem> NavigationCommand { get; set; }   


        public MainWindowViewModel(IRegionManager regionManager,IModuleManager moduleManager)
        {
            NavigationCommand = new DelegateCommand<MenuItem>(Navigation);
            this.regionManager = regionManager;
            
        }

        private void Navigation(MenuItem obj)
        {
            if(obj == null || string.IsNullOrEmpty(obj.NameSpace))
            {
                return;
            }
            regionManager.Regions[MainRegion].RequestNavigate(obj.NameSpace);
        }

        void CreateMenuBar()
        {
            Menus = new ObservableCollection<MenuItem>
            {
                new MenuItem()
                {
                    Title = "编码解码",
                    Icon = "\ue628",// 转义字符  &#xe628; => \ue628
                    NameSpace = "Coding"
                },
                new MenuItem()
                {
                    Title = "图片转编码",
                    Icon = "\ue628",
                    NameSpace = ""
                }
            };
        }

        
    }
}
