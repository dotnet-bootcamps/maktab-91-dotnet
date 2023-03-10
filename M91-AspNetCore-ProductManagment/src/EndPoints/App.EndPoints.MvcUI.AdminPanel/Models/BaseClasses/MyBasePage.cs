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

        public bool UseHasSuitableRole()
        {
            if (DateTime.Now.Second % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
