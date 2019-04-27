
using CalendarAPI.Data.Context;
using CalendarAPI.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CalendarAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            

            services.AddMvc(options =>   //Veri tipi json olarak ayarlandı.
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            });
            services.AddMvc(opts =>
            {
                opts.Filters.Add(new AutoLogAttribute());
            });

            //Veritabanı bağlantısı
            services.AddDbContext<CalendarDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/api/error", "?statusCode={0}");
            app.UseMvc();
            RewriteOptions rewriteOptions = new RewriteOptions().AddRedirect("favicon.ico", "images/favicon.ico");

            app.UseRewriter(rewriteOptions);
        }
    }
}
