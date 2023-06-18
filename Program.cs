using NoorSubmission.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NoorSubmission.Controllers;

var builder = WebApplication.CreateBuilder(args);


//TODO: Frontend Application should never connect to DB. Frontend speaks to API. API Speaks to DB.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));

//TODO: This needs to be deleted. This is not how to call an API from a Frontend application 
builder.Services.AddScoped<MainFormModelsAPIController>();

builder.Services.AddControllersWithViews();

//TODO: Frontend Application should never have Swagger. Delete this
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


//TODO: Frontend Application should never have Swagger. Delete this

app.UseSwagger();

//TODO: Frontend Application should never have Swagger. Delete this

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
