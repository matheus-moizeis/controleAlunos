using ControleAlunosMVC.Data;
using ControleAlunosMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ControleAlunosMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ControleAlunosMVCContext") ?? throw new InvalidOperationException("Connection string 'ControleAlunosMVCContext' not found.")));

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectsService>();
builder.Services.AddScoped<ScoreService>();

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

UpdateDatabase();

app.Run();

void UpdateDatabase()
{
    var connection = builder.Configuration.GetConnectionString("ConnectionDatabase");
    var nameDatabase = builder.Configuration.GetConnectionString("NameDatabase");
    Database.CreateDatabase(connection, nameDatabase);
}
