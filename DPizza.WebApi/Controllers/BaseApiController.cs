using DPizza.WebApi.Infrastracture.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DPizza.WebApi.Controllers
{
    //This code snippet shows a base abstract class `BaseApiController` that serves as a common base for other API controllers in an ASP.NET Core application. Let's break down the key components of this class:
    //1. `[ApiController]`: This attribute is used to indicate that the class is an API controller. It is a part of ASP.NET Core's attribute routing feature.
    //2. `[ApiResultFilter]`: This attribute is a custom filter attribute that may be used to apply result transformations to the action method's return value. It is not a built-in attribute in ASP.NET Core, so its behavior would depend on how it is implemented in the application.
    //3. `[Route("api/v{version:apiVersion}/[controller]/[action]")]`: This attribute specifies the route template for the API controller. It includes a route parameter `{version:apiVersion}` which allows versioning of the API. The `[controller]` and `[action]` tokens will be replaced with the controller and action names respectively.
    //4. `public abstract class BaseApiController : ControllerBase`: This class is defined as abstract, meaning it cannot be instantiated directly. It inherits from `ControllerBase`, which is the base class for ASP.NET Core controllers.
    //5. `private IMediator _mediator;`: This private field `_mediator` is used to store an instance of the `IMediator` interface. `IMediator` is typically used for implementing the Mediator pattern in ASP.NET Core applications.
    //6. `protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();`: This is a property `Mediator` that provides access to the `_mediator` field. It uses the null-coalescing assignment operator `??=` to lazily initialize the `_mediator` field using the `IMediator` service obtained from the current HTTP context's request services.
    //Overall, this base class sets up the structure for API controllers in the application, including handling of the `IMediator` dependency for implementing Mediator pattern-based communication between components.
    [ApiController]
    [ApiResultFilter]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
