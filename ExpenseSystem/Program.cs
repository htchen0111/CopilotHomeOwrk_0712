using ExpenseSystem.Common.Validator;
using ExpenseSystem.Data;
using ExpenseSystem.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 註冊 ExpenseDbContext 用 InMemoryDb
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseInMemoryDatabase("ExpenseSystem"));

builder.Services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ExpenseValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 添加這行來啟用 API 控制器的屬性路由
app.MapControllers();

// 初始化資料庫
using (var scope = app.Services.CreateScope())
{
    var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
    databaseInitializer.Initialize();
}

app.Run();
