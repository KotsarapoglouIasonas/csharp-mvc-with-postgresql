using exercise.api.DataContext;
using exercise.api.Endpoints;
using exercise.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<iEmployeeRepo, EmployeeRepo>();
builder.Services.AddDbContext<EmployeeContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureEmployeeApi();
app.ConfigureDepartmentApi();
app.ConfigureSalaryApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
