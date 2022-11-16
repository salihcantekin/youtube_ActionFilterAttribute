using ActionFilterAttribute.WebApi.ActionFilters;
using ActionFilterAttribute.WebApi.Models;
using ActionFilterAttribute.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterAttribute.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[RequireTenantName(headerKey: "tenant-name")]
public class TenantController : ControllerBase
{
    private readonly TenantUserService tenantUserService;

    public TenantController(TenantUserService tenantUserService)
    {
        this.tenantUserService = tenantUserService;
    }

    [HttpGet]
    public ActionResult GetUsers()
    {
        var users = tenantUserService.GetAllUsers();

        return Ok(users);
    }


}
