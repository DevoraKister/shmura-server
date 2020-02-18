using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace BL.Models
{
    public class UserLoggedAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new UserLoggedParameterBinding(parameter);
        }
    }

    public class UserLoggedParameterBinding : HttpParameterBinding
    {
        IdialEntities3 db = new IdialEntities3();
        public UserLoggedParameterBinding(HttpParameterDescriptor parameter)
            : base(parameter)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
        HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;
            var identity = user.Identity as ClaimsIdentity;
            var claim = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(s => s.Value).SingleOrDefault();
            var u= db.User.Where(w => w.UserMail == claim).FirstOrDefault();
            actionContext.ActionArguments[Descriptor.ParameterName] = user;
            return Task.FromResult<object>(null);
        }
    }

}