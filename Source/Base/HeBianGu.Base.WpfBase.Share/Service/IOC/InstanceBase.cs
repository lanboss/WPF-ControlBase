﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;

namespace HeBianGu.Base.WpfBase
{
    public class LazyInstance<T> where T : new()
    {
        public static T Instance = new Lazy<T>(() => new T()).Value;
    }

    public class LazyNotifyInstance<T> : NotifyPropertyChangedBase where T : new()
    {
        public static T Instance = new Lazy<T>(() => new T()).Value;
    }

    public class ServiceInstance<T> : NotifyPropertyChangedBase
    {
        public static T Instance = ServiceRegistry.Instance.GetInstance<T>();
    }
}