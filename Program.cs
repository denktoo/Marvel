using Microsoft.EntityFrameworkCore;
using Marvel.Data;
using Marvel.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<MarvelContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 26))));

// Register services for dependency injection
builder.Services.AddScoped<ICharactersRepository, CharactersRepository>();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IPlanetsRepository, PlanetsRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

// Add services for controllers
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Seed the database (optional)
SeedData.Initialize(app.Services);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define default route pattern for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map API routes
app.MapControllers();

app.Run();