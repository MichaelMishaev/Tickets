using exercise.Domain.Contracts;
using exercise.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("MainDbConnection");

builder.Services.AddScoped<AgentDBInit>();
builder.Services.AddSingleton<IDateTime,DateTimeProvider>();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.EnableAnnotations();
});



builder.Services.AddDbContext<AgentDBContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}



app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseAuthorization();



await AgentDBInit.SeedAsync(app.Services);
app.Run();
