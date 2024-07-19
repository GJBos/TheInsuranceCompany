using System.Reflection;
using TIC.DomainAPI;
using TIC.ServiceAdapter;
using TIC.ServiceAdapter.Services;
using TIC.WebAPI.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
//var assemblies =  Directory.GetFiles(path, "TIC*.dll").Select(Assembly.LoadFile).ToList();
builder.Services.Scan(scan => scan.FromAssemblyOf<IInsuranceDomain>().AddClasses().AsImplementedInterfaces().WithTransientLifetime());
builder.Services.Scan(scan => scan.FromAssemblyOf<IInsuranceProvider>().AddClasses().AsImplementedInterfaces().WithTransientLifetime());
builder.Services.Scan(scan => scan.FromAssemblyOf<IGetDutchTravelInsurances>().AddClasses().AsImplementedInterfaces().WithTransientLifetime());
builder.Services.Scan(scan => scan.FromAssemblyOf<IAddInsuranceRequestMapper>().AddClasses().AsImplementedInterfaces().WithTransientLifetime());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
