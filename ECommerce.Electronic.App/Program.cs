using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete.CustomerServices;
using BusinessLogic.Mapping;
using BusinessLogic.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ICustomValidator>());

builder.Services.AddAutoMapper(typeof(ICustomMapper));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService ,CategoryService>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IColorRepository, EfColorRepository>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
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
