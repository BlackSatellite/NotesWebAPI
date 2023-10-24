using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //Couldn't solve the problem with getting ClaimTypes.NameIdentifier, returns always null Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value

        //internal Guid UserId => !User.Identity.IsAuthenticated ? Guid.Empty : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //internal Guid UserId
        //{
        //    get
        //    {
        //        if (!User.Identity.IsAuthenticated)
        //        {
        //            return Guid.Empty;
        //        }

        //        var userIdClaim = User.FindFirst(ClaimTypes.Name);

        //        if (userIdClaim != null)
        //        {
        //            if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        //            {
        //                return userId;
        //            }
        //        }

        //        return Guid.Empty;
        //    }
        //}

        internal Guid UserId
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Guid.Empty;
                }

                return Guid.NewGuid();
            }
        }
    }
}
