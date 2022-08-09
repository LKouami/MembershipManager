using MembershipManager.Models;
using MembershipManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MembershipDatabaseSettings>(
builder.Configuration.GetSection("MembershipDatabase"));
builder.Services.AddSingleton<MembersService>();
builder.Services.AddSingleton<CommunesService>();
builder.Services.AddSingleton<PrefecturesService>();
builder.Services.AddSingleton<RegionsService>();
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
