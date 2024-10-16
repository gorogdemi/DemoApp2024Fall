using DemoApp2024Fall;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog(
    options =>
        options
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("log.txt"));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonService, PersonService>();

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

// TODO: DI: Singleton, Scoped, Transient
// TODO: Exercise: counter endpoint
// TODO: Cleanup
// TODO: Person: Id, Name, Email, BirthDate
// TODO: IPersonService + Implementation with List
// TODO: PersonController: CRUD endpoints with exercise
// TODO: Input validation: Required, MaxLength, Email, Range
// TODO: Add log messages
// TODO: Serilog: Serilog.AspNetCore 8.0.3