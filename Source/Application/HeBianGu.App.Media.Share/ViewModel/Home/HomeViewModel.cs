﻿using HeBianGu.Service.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.App.Media.ViewModel.Home
{
    [ViewModel("Home")]
    internal class HomeViewModel : MvcViewModelBase
    {
        #region - 属性 -

        #endregion

        #region - 命令 -

        #endregion

        #region - 方法 -

        protected override void RelayMethod(object obj)
        {
            string command = obj.ToString();

            //  Do：应用
            if (command == "Sumit")
            {


            }
            //  Do：取消
            else if (command == "Cancel")
            {


            }
        }

        #endregion
    }

}
