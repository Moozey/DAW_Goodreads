using Goodreads.Data;
using Goodreads.Helpers.Extensions;
using Goodreads.Helpers.Seeders;
using Goodreads.Repositories.BookRepository;
using Goodreads.Services.BookService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//connect db
builder.Services.AddDbContext<GoodreadsContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories + services
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeders();


var app = builder.Build();
SeedData(app);
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


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<BookSeeder>();
        service.SeedInitialBooks();

        var service1 = scope.ServiceProvider.GetService<AuthorSeeder>();
        service1.SeedInitialAuthors();
    }
}