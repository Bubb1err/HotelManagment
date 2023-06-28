using HotelManagment.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureDefaultIdentity();

builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
  "Management",
  "Management",
  "Management/{controller=Reports}/{action=All}");

app.MapControllerRoute(
  "default",
  "{controller=Home}/{action=Index}/{id?}");

app.Run();