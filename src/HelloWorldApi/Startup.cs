using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorldApi
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "CORS";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.DefaultPolicyName = DefaultCorsPolicyName;
                options.AddPolicy(DefaultCorsPolicyName,
                                  builder =>
                                  {
                                      builder.AllowAnyHeader()
                                             .AllowAnyMethod()
                                             .AllowAnyOrigin()
                                             .AllowCredentials();
                                  });
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(DefaultCorsPolicyName);
            app.UseMvc();

            app.Run(async context =>
            {
                var message = context.Request.Query.TryGetValue("name", out var name) ? $"Hello {name}!" : "Hello World!";

                await context.Response.WriteAsync(message);
            });
        }
    }
}