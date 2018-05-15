using Health.Web.Configuration;
using Health.Web.Data;
using Health.Web.Extensions;
using Health.Web.Models;
using LinqToDB;
using LinqToDB.DataProvider.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Health.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Health REST APIs",
                    Description = "REST APIs for health",
                    TermsOfService = "None"
                });

                // Se decommento ottengo un'eccezione quando ho un controller (es. CategoriesController) che estende un altro controller.
                // Set the comments path for the Swagger JSON and UI.
                //var basePath = AppContext.BaseDirectory;
                //var xmlPath = Path.Combine(basePath, "REST.xml");
                //c.IncludeXmlComments(xmlPath);
            });

            services.Configure<Kendo>(Configuration.GetSection("kendo"));
            services.Configure<Theme>(Configuration.GetSection("theme"));

            var dbFactory = new HealthDataContextFactory(
                dataProvider: SQLiteTools.GetDataProvider(),
                connectionString: Configuration.GetConnectionString("Health")
            );

            services.AddSingleton<IDataContextFactory<HealthDataContext>>(dbFactory);
            SetupDatabase(dbFactory);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });

            /*
             Shortcut per:

             routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
             */
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Oops, something went wrong");
            });
        }

        void SetupDatabase(IDataContextFactory<HealthDataContext> dataContext)
        {
            using (var db = dataContext.Create())
            {
                db.CreateTableIfNotExists<FitbitDevice>();
                db.CreateTableIfNotExists<Heartbeat>();
                db.CreateTableIfNotExists<Category>();

                db.InsertOrReplace(new FitbitDevice { Id = "D1", AccountId = "A1" });
                db.InsertOrReplace(new FitbitDevice { Id = "D2", AccountId = "A2" });

                db.Insert(new Heartbeat { DeviceId = "D1", Timestamp = DateTime.Now, Value = 60 });
                db.Insert(new Heartbeat { DeviceId = "D1", Timestamp = DateTime.Now, Value = 80 });
                db.Insert(new Heartbeat { DeviceId = "D1", Timestamp = DateTime.Now, Value = 65 });
                db.Insert(new Heartbeat { DeviceId = "D2", Timestamp = DateTime.Now, Value = 60 });
                db.Insert(new Heartbeat { DeviceId = "D2", Timestamp = DateTime.Now, Value = 70 });

                db.InsertOrReplace(new Category { Id = 1, Name = "Band" });
                db.InsertOrReplace(new Category { Id = 2, Name = "Smartwatch" });
            }
        }
    }
}
