using Sukuposti.Application.Services.Implementations;
using Sukuposti.Domain.Models;
using Sukuposti.Infrastructure.Repository.Implementations;
using Sukuposti.Infrastructure.Repository.Repositories;

namespace Sukuposti.API;

public static class Initializer
{
    public static async Task InitializeSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Your API Documentation",
                Version = "v1",
                Description = "Description of your API",
                Contact = new OpenApiContact()
                {
                    Name = "Your name",
                    Email = "your@email.com",
                }
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        
         await Task.CompletedTask;
    }
    
    public static async Task InitializeRepositories(this IServiceCollection service)
    {
        service.AddScoped<IImageRepository, ImageRepository>();
        service.AddScoped<IHorseRepository, HorseRepository>();

        await Task.CompletedTask;
    }
    
    public static async Task InitializeServices(this IServiceCollection service)
    {
        service.AddScoped<IJwtService, JwtService>();
        service.AddTransient<IEmailSender, SendGridLinkBuilder>();
        service.AddScoped<ISendGridLinkBuilder, SendGridLinkBuilder>();
        
        service.AddScoped<IImagesService, ImageService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IHorseService, HorseService>();
        
        await Task.CompletedTask;
    }

    public static async Task InitializeAuth(this IServiceCollection service, WebApplicationBuilder builder)
    {
        service.AddIdentity<User, IdentityRole<int>>(opts =>
            {
                opts.SignIn.RequireConfirmedAccount = true;
                opts.User.RequireUniqueEmail = true;
                opts.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<IdentityRole<int>>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>("Sukuposti.API")
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
        
        service.Configure<IdentityOptions>(opts =>
        {
            opts.Password.RequireDigit = true;
            opts.Password.RequireLowercase = true;
            opts.Password.RequireUppercase = true;
            opts.Password.RequiredLength = 6;
            opts.Password.RequireNonAlphanumeric = true;
            opts.Password.RequiredUniqueChars = 1;

            opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            opts.Lockout.MaxFailedAccessAttempts = 5;
            opts.Lockout.AllowedForNewUsers = true;

            opts.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            opts.User.RequireUniqueEmail = false;
            opts.SignIn.RequireConfirmedEmail = true;
        });
        
        service.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                AuthenticationType = "Jwt",
                ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
                ValidAudience = builder.Configuration["JwtOptions:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });

        service.AddAuthorization(opts =>
        {
            opts.AddPolicy(Roles.User, policy => policy.RequireRole(Roles.User));
            opts.AddPolicy(Roles.Admin, policy => policy.RequireRole(Roles.Admin));
        });
        
        await Task.CompletedTask;
    }
}