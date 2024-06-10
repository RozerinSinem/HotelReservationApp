using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Services;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HotelReservationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'HotelReservationDbContextConnection' not found.");

builder.Services.AddDbContext<HotelReservationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<HotelReservationAppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HotelReservationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<HotelAdminService>();
builder.Services.AddScoped<SearchHotelService>();
builder.Services.AddHostedService<NightlyTasksService>();
builder.Services.AddTransient<IEmailService, EmailService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
