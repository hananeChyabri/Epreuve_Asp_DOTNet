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
                string defaultCulture = supportedCultures[1];   //Choisir la culture (c'est la d�finision du format selon la r�gion)
                options.SetDefaultCulture(defaultCulture);      //D�finir la culture par d�faut
                //options.AddSupportedCultures(supportedCultures);      //Si multilingue, d�finir les cultures support�es par le site
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
            builder.Services.AddHttpContextAccessor();  //Injection de d�pendance du HttpContext dans le SessionManager (Handlers)
            builder.Services.AddDistributedMemoryCache();   //Ajout d'espace m�moire pour lier les cookie � l'application

            builder.Services.AddSession(options =>          //Cr�ation d'un cookie pour sauvegarder la session
            {
                options.Cookie.Name = "ASP-Demo-Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            builder.Services.Configure<CookiePolicyOptions>(options =>  //D�finition des r�gles (pour �tre OK avec le RGPD)
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.AddScoped<PanierSessionManager>();   //Ajout du UserSessionManager (Handlers) par injection de d�pendance 


            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();       //Activation des Middlewares permettant le contr�le 

            app.UseCookiePolicy();  //du Cookie de Session durant chaque requ�te HTTP

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