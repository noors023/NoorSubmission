using NoorSubmission.Models;


var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllersWithViews();
 

var app = builder.Build();
 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

 
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
