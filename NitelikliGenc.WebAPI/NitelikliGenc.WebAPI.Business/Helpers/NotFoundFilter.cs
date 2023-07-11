using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NitelikliGenc.WebAPI.Business.Services.Products;
using NitelikliGenc.WebAPI.DataAccess.Repositories;

namespace NitelikliGenc.WebAPI.Business.Helpers;

public class NotFoundFilter : ActionFilterAttribute
{
    private readonly IProductService _productService;

    public NotFoundFilter(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var id = (Guid)context.ActionArguments.Values.FirstOrDefault();

        var product = await _productService.GetByIdAsync(id);

        if (product != null)
        {
            await next();
        }

        context.Result = new NotFoundObjectResult("Products not found (filter)");
    }
}