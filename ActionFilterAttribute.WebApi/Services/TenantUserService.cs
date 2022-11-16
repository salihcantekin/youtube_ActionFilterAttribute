using ActionFilterAttribute.WebApi.Models;

namespace ActionFilterAttribute.WebApi.Services;

public class TenantUserService
{
    private readonly TenantModel tenantModel;

    public TenantUserService(TenantModel tenantModel)
    {
        this.tenantModel = tenantModel;
    }

    public IEnumerable<User> GetAllUsers()
    {
        // go db and get Tenant's user
        // TODO Tenant Name is required

        return new List<User>()
        {
            new User() { Id = 1, EmailAddress = $"salihcantekin@gmail.com_{tenantModel.Name}"}
        };
    }
}
