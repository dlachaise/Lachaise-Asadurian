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
    public class AuthorizationFitler : Attribute, IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;

        public AuthorizationFitler(ISessionLogic sessionsLogic)
	{
		this.sessions = sessionsLogic;
	}
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];

            if (String.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Debe ingresar un token en el Encabezado",
                };
            }
            else
            {
                var session = this.GetSessionLogic(context);

                if (!sessions.IsValidToken(token))
                {
                    context.Result = new ContentResult(respnse)
                    {
                        StatusCode = 403,
                        Content = "No tenes permisos"
                    };
                }
            }

            if (sessions.IsValidToken(token))
            {
                ResponseDTO response = new ResponseDTO
                {
                    Code = 3002,
                    ErrorMessage = "El userToken ingresado no es correcto",
                    IsSuccess = false
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = 403,
                };
            }
        }
        public ISessionLogic GetSessionLogic(AuthorizationFilterContext context)
        {
            var sessionType = typeof(ISessionLogic);

            return context.HttpContext.RequestServices.GetService(sessionType) as ISessionLogic;
        }
        /*
            ESTE METODO DEBERIA IR EN SU CAPA LOGICA!!!
            Encapsulado la logica para autorizar usuarios en su sistema
            ESTE ES UN EJEMPLO SIN LOGICA!!
         */
      
    }
}