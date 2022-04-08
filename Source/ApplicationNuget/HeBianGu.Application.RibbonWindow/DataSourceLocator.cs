﻿using HeBianGu.Base.WpfBase;

namespace HeBianGu.Application.RibbonWindow
{
    internal class DataSourceLocator
    {
        public DataSourceLocator()
        {
            ServiceRegistry.Instance.Register<ShellViewModel>();
        }
        public ShellViewModel ShellViewModel => ServiceRegistry.Instance.GetInstance<ShellViewModel>();

    }
}