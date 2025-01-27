﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using HeBianGu.General.WpfControlLib;
using System;

namespace HeBianGu.Window.MessageDialog
{
    public class MessageDialogService : IMessageDialog
    {
        public bool ShowDialog(string messge, string title = null, int closeTime = -1, bool showEffect = true, params Tuple<string, Action>[] acts)
        {
            return MessageDialogWindow.ShowDialog(messge, title, closeTime, showEffect, acts);
        }

        /// <summary> 显示窗口 </summary>
        public int ShowDialogWith(string messge, string title = null, bool showEffect = false, params Tuple<string, Action<IMessageDialogWindow>>[] acts)
        {
            return MessageDialogWindow.ShowDialogWith(messge, title, showEffect, acts);
        }

        /// <summary> 只有确定的按钮 </summary>
        public bool ShowSumit(string messge, string title = null, bool showEffect = false, int closeTime = -1)
        {
            return MessageDialogWindow.ShowSumit(messge, title, showEffect, closeTime);
        }

    }
}
