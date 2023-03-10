using Moorit.Data;
using Moorit.Repository;
using Microsoft.EntityFrameworkCore;
using Moorit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Moorit
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(
            //       Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            // OVO SAM NAMERNO SKLONIO PROVERI TREBA LI ZALOKAL MOZE IZAZVATI PROBLEME
            //services.AddCors(o =>
            //{
            //    o.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});

            //services.AddAutoMapper(typeof(Maps));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "Moorit API",
            //        Title = "Moorit API",
            //        Version = "v1",
            //        Description = "API for a Moorit"
            //    });
            //    var xfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xpath = Path.Combine(AppContext.BaseDirectory, xfile);
            //    c.IncludeXmlComments(xpath);
            //});

            services.AddIdentity<ApplicationUserModel, IdentityRole>().AddEntityFrameworkStores<MooritContext>().AddDefaultTokenProviders();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMvc();
            //services.AddSingleton<ILoggerService, LoggerService>();

            services.AddDbContext<MooritContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MooritDB")));

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.SaveToken = true;
                    option.RequireHttpsMetadata = false;
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))

                    };
                });

            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IMooringRepository, MooringRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
