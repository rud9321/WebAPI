using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI.Secure
{
    public class SecureAuthorize : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedauthenticationToken =Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamepasswordArray = decodedauthenticationToken.Split(':');
                string usernaem, password = string.Empty;
                usernaem = usernamepasswordArray[0];
                password = usernamepasswordArray[1];
                if (usernaem == "rudra" && password == "123")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(usernaem),null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}