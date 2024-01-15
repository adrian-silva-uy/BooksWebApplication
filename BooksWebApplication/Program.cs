using BooksWebApplication.Infrastructure;
using BooksWebApplication.Infrastructure.Interfaces;
using BooksWebApplication.Infrastructure.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBookRepository>(b => new BookRepository(@"Data Source=LENOVO_R3;Database=Ballast_Lane_Books;Integrated Security=sspi;"));
builder.Services.AddScoped<BookService>();

builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Book service API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger setup
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book service API"));
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
