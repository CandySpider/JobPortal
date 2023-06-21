
using JobPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JobPortalContextConnection") ?? throw new InvalidOperationException("Connection string 'JobPortalContextConnection' not found.");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JobPortalDbContext>( options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:JobPortalDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<JobPortalDbContext>();


builder.Services.AddScoped<IJobRepository,JobRepository>();
builder.Services.AddScoped<ISkillSetRepository,SkillSetRepository>();
builder.Services.AddScoped<ISkillRepository,SkillRepository>();
builder.Services.AddScoped<IApplicationRepository,ApplicationRepository>();
builder.Services.AddScoped<IEmployerRepository,EmployerRepository>();
builder.Services.AddScoped<ICandidateRepository,CandidateRepository>();
builder.Services.AddScoped<IAboutRepository,AboutRepository>();
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
app.UseAuthentication();;

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
DbInitializer.FirstTime(app);

using (var roleScope = app.Services.CreateScope())
{
    var myRoleManager = roleScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] {"Employer", "Candidate", "Admin" };
    foreach ( var i in roles )
    {
        if(!await myRoleManager.RoleExistsAsync(i))
        {
            await myRoleManager.CreateAsync(new IdentityRole(i));
        }
    }
}
app.Run();

