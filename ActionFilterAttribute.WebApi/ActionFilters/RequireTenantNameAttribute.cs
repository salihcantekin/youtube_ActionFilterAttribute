using ActionFilterAttribute.WebApi.Exceptions;
using ActionFilterAttribute.WebApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterAttribute.WebApi.ActionFilters;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class RequireTenantNameAttribute : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
{
    public RequireTenantNameAttribute(string headerKey = "tenant-name")
    {
        this.headerKey = headerKey;
    }

    private readonly string headerKey;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionDescriptor.FilterDescriptors.Any(i => i.Filter.GetType() == typeof(RequireTenantNameAttribute)))
            return;

        var header = context.HttpContext.Request.Headers;

        if (header is null || !header.Any() || !header.ContainsKey(headerKey))
            throw new MissingTenantNameException();

        var tenantName = header[headerKey].ToString();

        var tenantModel = context.HttpContext.RequestServices.GetService(typeof(TenantModel)) as TenantModel;

        tenantModel.Name = tenantName;
    }
}
