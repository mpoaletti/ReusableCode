using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Nuget packeges to install:
//IdentityModel
//Microsoft.AspNet.Owin
//Microsoft.Owin
//Okta.AspNet
//Owin
//Microsoft.AspNet.Identity.Core
//Microsoft.Owin.Security.Cookies
//Microsoft.Owin.Security.OpenIdConnect
//IdentityModel.Client   (Version 3.80)
//Microsoft.AspNet.Identity.Owin
//Microsoft.Owin.Host.SystemWeb
//Microsoft.Owin.Security.Jwt
//Okta.AspNet
//Microsoft.Web.Infrastructure

//Create OWIN Startup file (Add New item > OWIN Startup Class) see startup.cs

//usings to include in startup.cs:
//using IdentityModel.Client;
//using Microsoft.AspNet.Identity;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.Owin;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.OpenIdConnect;
//using Owin;
//using System.Collections.Generic;
//using System.Security.Claims;



namespace BoilerPlateDraft.Code_Repo
{
	public class OktaStartupLogin
    {

		//Login check and pull username from OKTA login credentials:
		//if (!Request.IsAuthenticated) {
                //Session["logInStatus"] = false;
                //Response.Redirect("WEBSITEPAGE", false);
            //}
        //else {
            //Session["Username"] = HttpContext.Current.GetOwinContext().Request.User.Identity.Name;
            //Session["logInStatus"] = true;
        //}
	}
}