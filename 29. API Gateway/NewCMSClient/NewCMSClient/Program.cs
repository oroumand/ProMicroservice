var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("bi", c =>
{
    c.BaseAddress = new Uri("http://localhost:7300/bi/");
});
builder.Services.AddHttpClient("news", c =>
{
    c.BaseAddress = new Uri("http://localhost:7300/news/");
});
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
