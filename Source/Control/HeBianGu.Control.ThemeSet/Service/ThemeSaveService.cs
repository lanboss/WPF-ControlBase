﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using HeBianGu.Base.WpfBase;

namespace HeBianGu.Control.ThemeSet
{
    public class ThemeSaveService : IThemeSaveService
    {
        public void Save()
        {
            ThemeConfig.Instance = ThemeViewModel.Current.SaveTo();

            ThemeConfig.Instance.Save(out string message);
        }
    }
}
