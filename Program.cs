using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlackBook_System.Data;
using BlackBook_System.Models;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlackBook_SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlackBook_SystemContext") ?? throw new InvalidOperationException("Connection string 'BlackBook_SystemContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve files from wwwroot

// Configure additional static file serving for certificates
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates")),
    RequestPath = "/certificates"
});

// Ensure certificates directory exists
var certificatesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates");
if (!Directory.Exists(certificatesPath))
{
    Directory.CreateDirectory(certificatesPath);
}

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
