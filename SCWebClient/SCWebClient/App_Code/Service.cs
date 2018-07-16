using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCService;

/// <summary>
/// Summary description for Service
/// </summary>
public class Service
{
    static private LoginServiceClient _loginService = null;
    static private MainServiceClient _MainService = null;

   static public LoginServiceClient LoginService
    {
        get
        {
            if (_loginService == null) _loginService = new LoginServiceClient();
            return _loginService;
        }
    }

    static public MainServiceClient MainService
    {
        get
        {
            if (_MainService == null) _MainService = new MainServiceClient();
            return _MainService;
        }
    }
}