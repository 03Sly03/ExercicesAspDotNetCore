using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using ContactsWebApplication.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// 3 m�thodes pour enregistrer le Service/Repository/DbContext...(UploadService)
// -> builder.Services.Add____<ContactRepository>();

// Ici on ajoute le FakeContactDb.cs
builder.Services.AddSingleton<FakeContactsDb>();
// et se retrouve � l'int�rieur du conteneur de d�pendances
// L'injection � la cr�tion de ce qui � besoin du service dans le constructeur.

// Deuxi�me exemple avec les ouistitis
//builder.Services.AddSingleton<FakeMarmosetDb>();

//m�thode a utiliser pour enregistrer un db context et pouvoir utiliser efcore

// cas ONConfiguring
//builder.Services.AddDbContext<ApplicationDbContext>();

// Enregistrer pour les repositories
builder.Services.AddScoped<IRepository<Marmoset>, MarmosetRepository>();

// Ajout service de Session
builder.Services.AddSession();

// cas fichier appsettigns.json pour le ConnectionString
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline. /!\ l'ordre des middlewares a un impact.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Utilisation du middleware Session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
 