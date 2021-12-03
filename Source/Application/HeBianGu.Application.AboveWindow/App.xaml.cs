﻿using HeBianGu.Base.WpfBase;
using HeBianGu.Control.ThemeSet;
using HeBianGu.General.WpfControlLib;
using HeBianGu.Service.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HeBianGu.Application.AboveWindow
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : ApplicationBase
    {
        protected override System.Windows.Window CreateMainWindow(StartupEventArgs e)
        {
            return new ShellWindow(); 

            //base.OnStartup(e);

            //string sss = "1.80706845E-08";

            //double m = Math.Pow(0.1111111,10);

            //string ss = m.ToString();

            //bool r = double.TryParse(sss, out double dd);

            //decimal sssss = (decimal)dd;
        }


        protected override void ConfigureServices(IServiceCollection services)
        {
            //  Do ：注册本地化配置读写服务
            services.AddSingleton<IThemeSerializeService, LocalizeService>();

            //  Do ：注入领域模型服务
            services.AddSingleton<IAssemblyDomain, AssemblyDomain>();

            ////  Do ：注册日志服务
            //services.AddSingleton<ILogService, AssemblyDomain>();


            //services.UseMessageWindow();

            services.UseWindowAnimation(); 

        }

        protected override void Configure(IApplicationBuilder app)
        {

            //  Do：注册Mvc模式
            app.UseMvc(); 

            //  Do：设置默认主题
            app.UseLocalTheme(l =>
            {
                l.AccentColor = (Color)ColorConverter.ConvertFromString("#FF003D99");
                //l.ForegroundColor = (Color)ColorConverter.ConvertFromString("#727272");

                l.SmallFontSize = 15D;
                l.LargeFontSize = 18D;
                l.FontSize = FontSize.Small;

                l.ItemHeight = 35;
                //l.ItemWidth = 120;
                l.ItemCornerRadius = 2;

                l.AnimalSpeed = 5000;

                l.AccentColorSelectType = 0;

                l.IsUseAnimal = false;

                l.ThemeType = ThemeType.Light;

                l.Language = Language.Chinese;

                l.AccentBrushType = AccentBrushType.RadialGradientBrushReverse;
            });
        }

    }

}