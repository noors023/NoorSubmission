using NoorSubmission.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NoorSubmission.Controllers;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));
 
builder.Services.AddScoped<MainFormModelsAPIController>();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

 
 
    app.UseSwagger(); 

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "MainForm",
  pattern: "{controller=MainForm}/{action=MainformIndex}/{id?}" );

app.MapControllerRoute(
  name: "Read",
  pattern: "{controller=ReadMainForm}/{action=Index}/{id?}");

   

app.Run();
