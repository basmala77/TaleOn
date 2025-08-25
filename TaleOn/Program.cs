using AccessData;
using AccessData.Middleware;
using AccessData.Repos;
using AccessData.Repos.IRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Mapper;
using Scalar.AspNetCore;
using System.Text;
using TaleOn.Services.ControllerService;
using TaleOn.Services.ControllerService.IControllerService;

namespace TaleOn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddCors();

            // Add database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration["Redis:Configuration"];
                options.InstanceName = builder.Configuration["Redis:InstanceName"];
            });

            builder.Services.AddTransient<IEmailSend, EmailSend>();
            builder.Services.AddTransient<AccessData.Repos.IRepo.IOtpService, AccessData.Repos.OtpService>();
            // Configure Identity
            builder.Services.AddIdentity<Models.Entities.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            builder.Services.AddHttpClient();


            // Add Repositories
            builder.Services.AddScoped<IUserRepos, UserRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IParentService, ParentService>();

            //builder.Services.AddScoped<IUserService, UserService>();
            // Add OpenAPI with Bearer Authentication Support
            builder.Services.AddOpenApi("V1", options =>
            {
                options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            });

            // JWT Auth
            var key = Encoding.ASCII.GetBytes(builder.Configuration["ApiSettings:Secret"]);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromDays(7)
                };
            });

            //Register the global exception handler
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaleOn API V1");
                    c.DocumentTitle = "TaleOn API Explorer";
                });

                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            // redirect root to swagger
            app.MapGet("/", () => Results.Redirect("/swagger"));

            app.UseHttpsRedirection();
            
            // Serve static files from wwwroot
            app.UseStaticFiles();

            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();




            app.Run();
        }
    }
}
