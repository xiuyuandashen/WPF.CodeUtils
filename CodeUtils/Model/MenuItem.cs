using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUtils.Model
{
    public class MenuItem : BindableBase
    {
        /// <summary>
        /// 菜单标题
        /// </summary>
        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// 模块命名空间
        /// </summary>
        private string nameSpace;

        public string NameSpace
        {
            get { return nameSpace; }
            set { SetProperty(ref nameSpace, value); }
        }

        /// <summary>
        /// 图标
        /// </summary>
        private string icon;

        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

    }
}
