using Persistance.Interfaces;
using Persistance.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>(provider => new UserService());
builder.Services.AddTransient<IAnimalService, AnimalService>(provider => new AnimalService());
builder.Services.AddTransient<ICowService, CowService>(provider => new CowService());
builder.Services.AddTransient<IPigService, PigService>(provider => new PigService());
builder.Services.AddTransient<IProductService, ProductService>(provider => new ProductService());
builder.Services.AddTransient<IUserAnimalService, UserAnimalService>(provider => new UserAnimalService());
builder.Services.AddTransient<IUserProductService, UserProductService>(provider => new UserProductService());
builder.Services.AddTransient<ICheeseService, CheeseService>(provider => new CheeseService());
builder.Services.AddTransient<IEggService, EggService>(provider => new EggService());
builder.Services.AddTransient<ITemperatureService, TemperatureService>(provider => new TemperatureService());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
