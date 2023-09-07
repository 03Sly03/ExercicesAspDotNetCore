using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using ContactsWebApplication.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// 3 méthodes pour enregistrer le Service/Repository/DbContext...(UploadService)
// -> builder.Services.Add____<ContactRepository>();

// Ici on ajoute le FakeContactDb.cs
builder.Services.AddSingleton<FakeContactsDb>();
// et se retrouve à l'intérieur du conteneur de dépendances
// L'injection à la crétion de ce qui à besoin du service dans le constructeur.

// Deuxième exemple avec les ouistitis
//builder.Services.AddSingleton<FakeMarmosetDb>();

//méthode a utiliser pour enregistrer un db context et pouvoir utiliser efcore

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
 