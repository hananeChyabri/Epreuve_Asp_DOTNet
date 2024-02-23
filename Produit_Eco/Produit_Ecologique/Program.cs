using Produit_Ecologique.Handlers;
using Shared_Produit_Ecologique.Repositories;
using BLL = BLL_Produit_Ecologique;
using DAL = DAL_Produit_Ecologique;

namespace Produit_Ecologique
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                string[] supportedCultures = new string[]
                {
                    "en-US",    //Si en-US, alors le pattern des input de prix sera :  pattern="^\d*\.{0,1}\d*$"
                    "fr-BE"     //Si fr-BE, alors le pattern des input de prix sera :  pattern="^\d*,{0,1}\d*$"
                };
                string defaultCulture = supportedCultures[1];   //Choisir la culture (c'est la définision du format selon la région)
                options.SetDefaultCulture(defaultCulture);      //Définir la culture par défaut
                //options.AddSupportedCultures(supportedCultures);      //Si multilingue, définir les cultures supportées par le site
                //options.AddSupportedUICultures(supportedCultures);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProduitRepository<BLL.Entities.Produit>, BLL.Services.ProduitService>();
            builder.Services.AddScoped<IProduitRepository<DAL.Entities.Produit>, DAL.Services.ProduitService>();
            builder.Services.AddScoped<IMediaRepository<BLL.Entities.Media>, BLL.Services.MediaService>();
            builder.Services.AddScoped<IMediaRepository<DAL.Entities.Media>, DAL.Services.MediaService>();
            builder.Services.AddScoped<BLL.Services.CategorieService>();
            builder.Services.AddScoped<DAL.Services.CategorieService>();


            #region Session
            builder.Services.AddHttpContextAccessor();  //Injection de dépendance du HttpContext dans le SessionManager (Handlers)
            builder.Services.AddDistributedMemoryCache();   //Ajout d'espace mémoire pour lier les cookie à l'application

            builder.Services.AddSession(options =>          //Création d'un cookie pour sauvegarder la session
            {
                options.Cookie.Name = "ASP-Demo-Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            builder.Services.Configure<CookiePolicyOptions>(options =>  //Définition des règles (pour être OK avec le RGPD)
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.AddScoped<PanierSessionManager>();   //Ajout du UserSessionManager (Handlers) par injection de dépendance 


            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();       //Activation des Middlewares permettant le contrôle 

            app.UseCookiePolicy();  //du Cookie de Session durant chaque requête HTTP

            app.UseStaticFiles();

            app.UseRouting();
            //Localization
            app.UseRequestLocalization();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}