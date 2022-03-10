﻿using HeBianGu.Base.WpfBase;
using HeBianGu.Control.ThemeSet;
using HeBianGu.General.WpfControlLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HeBianGu.App.Media
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        protected override System.Windows.Window CreateMainWindow(StartupEventArgs e)
        {
            return new MainWindow();
        }


        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddMvc();

            ////  Do ：注入领域模型服务
            //services.AddSingleton<IAssemblyDomain, AssemblyDomain>();

            services.AddMessageDialog();

            //services.AddWindowAnimation();

            //services.AddStudentDemo();

            services.AddMessage();

            services.AddTheme();

            services.AddSetting();
            services.AddSettingViewPrenter();

            services.AddGuideViewPresenter();

            services.AddXmlSerialize();
            services.AddXmlMeta();

            ////  Do ：启用启动窗口 需要添加引用HeBianGu.Window.Start
            //services.AddStart();

            ////  Do ：启用启动窗口 需要添加引用HeBianGu.Systems.Identity
            //services.AddIdentity();
        }

        protected override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);

            app.UseMvc();
            app.UseMainWindowSetting();

            //  Do：设置默认主题
            app.UseLocalTheme(l =>
            {
                l.AccentColor = (Color)ColorConverter.ConvertFromString("#FF003D99");

                l.SmallFontSize = 14D;
                l.LargeFontSize = 16D;
                l.FontSize = FontSize.Small;

                l.ItemHeight = 36;
                l.RowHeight = 40;
                //l.ItemWidth = 120;
                l.ItemCornerRadius = 5;

                l.AnimalSpeed = 5000;
                l.AccentColorSelectType = 0;
                l.IsUseAnimal = false;

                l.ThemeType = ThemeType.Light;

                l.Language = Language.Chinese;

                l.AccentBrushType = AccentBrushType.LinearGradientBrush;
            });
        }

    }
}
