using dev_backend_habitly_eixo2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();//instala��o do runtime compilation
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//conex�o com o banco de dados SQL Server

//Configura��o de autentica��o por cookie
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
    });

builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", config =>
    {
        config.LoginPath = "/Usuarios/Login/";
        config.AccessDeniedPath = "/Usuarios/AccessDenied/";
    });

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

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed etiquetas padrão se ainda não existirem
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Garantir que o banco esteja acessível (não cria migration aqui)
    try
    {
        if (!db.Etiquetas.Any(e => e.Nome == "não iniciado") && !db.Etiquetas.Any(e => e.Nome == "em andamento") && !db.Etiquetas.Any(e => e.Nome == "concluído"))
        {
            db.Etiquetas.AddRange(
                new Etiqueta { Nome = "não iniciado" },
                new Etiqueta { Nome = "em andamento" },
                new Etiqueta { Nome = "concluído" }
            );
            db.SaveChanges();
        }
    }
    catch
    {
        // Se houver problemas de conexão (por exemplo durante migrações iniciais), não interrompe a inicialização.
    }
}

app.Run();
