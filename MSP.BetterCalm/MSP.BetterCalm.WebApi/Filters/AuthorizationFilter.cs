using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MSP.BetterCalm.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSP.BetterCalm.WebApi.Models;

namespace MSP.BetterCalm.WebApi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {


        public AuthorizationFilter()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = "Token is required",
                };
                return;
            }
            var sessions = GetSessions(context);
            if (!sessions.IsValidToken(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = "Invalid Token",
                };
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }

        private static ISessionLogic GetSessions(AuthorizationFilterContext context)
        {
            return (ISessionLogic)context.HttpContext.RequestServices.GetService(typeof(ISessionLogic));
        }
    }
}
