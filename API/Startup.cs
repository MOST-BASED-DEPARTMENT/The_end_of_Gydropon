using API.Interface;
using API.Models;
using API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            public IConfiguration Configuration
            {
                get;
            }
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddScoped< IAgriculturalMachinery, AgriculturalMachineryRepository >();
                services.AddDbContext<AgronomicAppTestUserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Data Source = 46.39.232.190; Initial Catalog = Agronomic_App_TestUser; User Id = TestUser; Password = vag!nA228##; Encrypt=False;")));
                services.AddSwaggerGen(options => {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "WEB API",
                        Version = "v1"
                    });
                });
                //Enable CORS
                services.AddCors(c => {
                    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });
            /*
             //JSON Serializer
            
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                return options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                
            }).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
                services.AddControllers();
            
             */
            }
            
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();
                app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
                });
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API");
                    c.DocumentTitle = "WEB API";
                    c.DocExpansion(DocExpansion.List);
                });
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                    RequestPath = "/Photos"
                });
            }
        }
    }
