using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public interface IActionModel
    {
        string NewAction { get; set; }
        ActionsModel ActionsModel { get; set; }
    }
}