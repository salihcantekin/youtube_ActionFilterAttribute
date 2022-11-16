namespace ActionFilterAttribute.WebApi.Exceptions;

public class MissingTenantNameException : Exception
{
    public MissingTenantNameException() 
        : base(message: "TenantName must be provided via header")
    {

    }
}
