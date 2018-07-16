using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SCHttpSeesion
/// </summary>
public static class SCHttpSeesion
{
    private static string _userFirstname;
    private static string _userLastname;
    private static string _username;

    public static string UserFirstname
    {
        get
        {
            if (HttpContext.Current.Session[SCHttpSeesion._userFirstname] == null)
            {
                // Return an empty string if session variable is null
                return null;
            }
            else
            {
                return HttpContext.Current.Session[SCHttpSeesion._userFirstname].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session[SCHttpSeesion._userFirstname] = value;
        }
    }

    public static string UserLastname
    {
        get
        {
            if (HttpContext.Current.Session[SCHttpSeesion._userLastname] == null)
            {
                // Return an empty string if session variable is null
                return null;
            }
            else
            {
                return HttpContext.Current.Session[SCHttpSeesion._userLastname].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session[SCHttpSeesion._userLastname] = value;
        }
    }

    public static string UserName
    {
        get
        {
            if (HttpContext.Current.Session[SCHttpSeesion._username] == null)
            {
                // Return an empty string if session variable is null
                return null;
            }
            else
            {
                return HttpContext.Current.Session[SCHttpSeesion._username].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session[SCHttpSeesion._username] = value;
        }
    }
}