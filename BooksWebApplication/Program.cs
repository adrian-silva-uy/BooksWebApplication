//using BooksWebApplication.Infrastrucuture.Interfaces;
//using BooksWebApplication.Infrastrucuture.ServiceLayer;
//using BooksWebApplication.Infrastrucuture;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddTransient<IBookRepository, BookRepository>();
//builder.Services.AddScoped<IBookService, BookService>();

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.UseHttpsRedirection();

////app.UseAuthorization();


//app.Run();

using BooksWebApplication.Domain;
using BooksWebApplication.Domain.Interfaces;
using BooksWebApplication.Domain.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Uncomment the following line if your application requires authorization.
// app.UseAuthorization();

app.MapControllers();

try
{
    // Your application setup code
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    throw;
}
