using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BlackBook_System.Data;
using BlackBook_System.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Load connection string
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(dbConnectionString))
{
    dbConnectionString = "Server=DESKTOP-H7249VE;Database=BlackBook;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
}
Console.WriteLine($"Using connection string: {dbConnectionString}");

// 🔹 Register DbContext
builder.Services.AddDbContext<BlackBookDbContext>(options =>
    options.UseSqlServer(dbConnectionString)
           .EnableSensitiveDataLogging()
           .EnableDetailedErrors()
           .LogTo(Console.WriteLine, LogLevel.Information));

// 🔹 Register Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<BlackBookDbContext>()
.AddDefaultTokenProviders();

// 🔹 Configure cookie paths
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.Cookie.Name = "BlackBook.Auth";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.SlidingExpiration = true;
    options.ReturnUrlParameter = "returnUrl";
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            if (context.Request.Path.StartsWithSegments("/Account/Login"))
            {
                context.Response.Redirect("/Account/Login");
            }
            return Task.CompletedTask;
        }
    };
});

// 🔹 Session Support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 🔹 Add MVC support
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PrincipalAccess", policy =>
        policy.RequireRole("Principal"));
        
    options.AddPolicy("TeacherAccess", policy =>
        policy.RequireRole("Teacher"));
        
    options.AddPolicy("PrincipalEditLeaveoutSheet", policy =>
        policy.RequireRole("Principal"));
        
    options.AddPolicy("TeacherEditLeaveoutSheet", policy =>
        policy.RequireRole("Teacher"));
});

var app = builder.Build();

// 🔹 Ensure wwwroot/certificates exists
var certificatesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates");
if (!Directory.Exists(certificatesPath))
{
    Directory.CreateDirectory(certificatesPath);
}

// 🔹 Middleware setup
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(certificatesPath),
    RequestPath = "/certificates"
});

app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// 🔹 Seed database if needed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BlackBookDbContext>();
        // Always run seed
        await BlackBook_System.Data.SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
        throw;
    }
}

// 🔹 Map routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
