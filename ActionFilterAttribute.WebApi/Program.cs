using ActionFilterAttribute.WebApi.ActionFilters;
using ActionFilterAttribute.WebApi.Models;
using ActionFilterAttribute.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(conf => 
{
    conf.Filters.Add<RequireTenantNameAttribute>();
    conf.Filters.Add<AdvangeLoggingAttribute>();
});

builder.Services.AddLogging();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CountryService>();
builder.Services.AddScoped<TenantUserService>();

builder.Services.AddScoped<TenantModel>(i => new TenantModel() { Name = "DEFAULT" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
