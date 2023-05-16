using FiltersDemo.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddMvc(options => 
options.Filters.Add(typeof(MyExceptionFilter)));

var app = builder.Build();

app.UseHttpsRedirection(); // by default, all requests will use https protocol
app.UseStaticFiles(); // to use static files from wwwroot folder


app.UseRouting(); // to enable routing


app.UseAuthorization(); // to enable authorization at application level

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

// app.UseRouting(); // to enable routing

app.Run();
