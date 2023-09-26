using BusinessLogic.Abstract;
using BusinessLogic.Concrete.Customers;
using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICategoryRepository,EfCategoryRepository>();

builder.Services.AddDbContext<MsECommerceContext>();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
    );
});

app.Run();
