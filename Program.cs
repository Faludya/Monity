using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Monity.Models;
using Monity.Repositories;
using Monity.Repositories.Interfaces;
using Monity.Services;
using Monity.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DbMonity");
builder.Services.AddDbContext<MonityContext>(options =>
                options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<MonityContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.Add(new ServiceDescriptor(typeof(ILog), new ConsoleLogger()));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddScoped<IAvatarRepository, AvatarRepository>();
builder.Services.AddScoped<IAvatarService, AvatarService>();

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IBoardService, BoardService>();

builder.Services.AddScoped<IBoardStatusRepository, BoardStatusRepository>();
builder.Services.AddScoped<IBoardStatusService, BoardStatusService>();

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddScoped<IUserBoardRepository, UserBoardRepository>();
builder.Services.AddScoped<IUserBoardService, UserBoardService>();

builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
builder.Services.AddScoped<IUserTaskService, UserTaskService>();

builder.Services.AddScoped<IBoardViewModelRepository, BoardViewModelRepository>();
builder.Services.AddScoped<IBoardViewModelService, BoardViewModelService>();

builder.Services.AddDbContext<MonityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbMonity")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
