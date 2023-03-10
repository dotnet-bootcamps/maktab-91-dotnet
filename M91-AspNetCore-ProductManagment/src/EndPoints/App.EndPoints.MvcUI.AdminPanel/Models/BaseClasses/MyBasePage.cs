using Microsoft.AspNetCore.Mvc.Razor;

namespace App.EndPoints.MvcUI.AdminPanel.Models.BaseClasses
{
    public abstract class MyBasePage<T> : RazorPage<T>
    {
        public string PageName
        {
            get;
            set;
        }
    }
}
