using Microsoft.Owin.Security.OAuth;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OrderManagement_Api
{
    public class MyAuthorizationServiceProvider:OAuthAuthorizationServerProvider
    {

        public override  async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext Context)
        {

            Context.Validated();

        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Validate_Users ObjValidate = new Validate_Users();

            var Validate_Result = ObjValidate.Validate(context.UserName, context.Password);

            if (Validate_Result == null)
            {
                context.SetError("Invalid Grant", "Provided User Name and Password is Incorrect");
                return;

            }

            var Claims = new List<Claim>();

            Claims.Add(new Claim(ClaimTypes.Name, Validate_Result.DRN_Emp_Code));

            var Identity = new ClaimsIdentity(Claims, context.Options.AuthenticationType);


            context.Validated(Identity);



        }
    }
}