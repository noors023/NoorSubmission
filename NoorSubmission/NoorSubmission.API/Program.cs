using NoorSubmission.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));
 

var app = builder.Build(); 
app.UseDefaultFiles();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
  name: "Get",
  pattern: "{controller=Submisson}/{action=GetForms}/{id?}");

app.MapControllerRoute(
  name: "Post",
  pattern: "{controller=Submisson}/{action=PostMainFormModel}/{id?}");


app.MapControllerRoute(
  name: "Delete",
  pattern: "{controller=Submisson}/{action=DeleteAllData}/{id?}");


app.MapControllerRoute(
  name: "Download",
  pattern: "{controller=Submisson}/{action=ExportReport}/{id?}");

app.Run();
