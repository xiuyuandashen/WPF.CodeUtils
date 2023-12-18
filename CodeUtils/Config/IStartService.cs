using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUtils.Config
{
    /// <summary>
    /// 初始化接口，让首页继承实现它在app.cs生命周期中调用
    /// </summary>
    public interface IStartService
    {
        void Start();
    }
}
