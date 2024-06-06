using MySqlConnector;
using Sukuposti.API;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Prod");
builder.Services.AddDbContext<ApiContext>(options =>
        options.UseMySql(connectionString,
            ServerVersion.Parse("8.3.0-mysql")).EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddSendGrid(options => 
    options.ApiKey = builder.Configuration.GetValue<string>("SendGridKey")
                     ?? throw new Exception("The 'SendGridApiKey' is not configured")
);

builder.Services.AddAutoMapper(typeof(Program));

await builder.Services.InitializeSwagger();
await builder.Services.InitializeRepositories();
await builder.Services.InitializeServices();
await builder.Services.InitializeAuth(builder);

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddTransient(x =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Prod")));

builder.Services.AddSendGrid(options => 
    options.ApiKey = builder.Configuration.GetValue<string>("SendGridKey")
                     ?? throw new Exception("The 'SendGridApiKey' is not configured")
);

var app = builder.Build();


app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
await app.RunAsync();
