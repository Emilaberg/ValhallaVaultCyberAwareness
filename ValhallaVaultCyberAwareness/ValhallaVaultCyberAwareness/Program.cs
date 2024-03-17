using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Components;
using ValhallaVaultCyberAwareness.Components.Account;
using ValhallaVaultCyberAwareness.Components.Middleware;
using ValhallaVaultCyberAwareness.Data;

using ValhallaVaultCyberAwareness.Data.Managers;


using ValhallaVaultCyberAwareness.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<IValhallaUow, ValhallaUow>();

//Dessa bör inte användas utan det är vårt uow som sköter det. uow innehåller alla repos.
//vi låter det ligga kvar för att inte förstöra kod som bygger på att dessa finns med.
builder.Services.AddScoped<SegmentRepository>();
builder.Services.AddScoped<SubCategoryRepository>();
builder.Services.AddScoped<QuestionRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<PromptRepository>();
builder.Services.AddScoped<UserRepository>();






builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

//används ej längre då denna hämtade key från lokala datorn för att koppla till azure databasen, nu kör vi lokala databasen istället
//var connectionString = new KeyManager().GetKey() ?? throw new ArgumentNullException("The specified path is not valid");

var connectionString = builder.Configuration.GetConnectionString("DbConnection") ?? throw new ArgumentNullException("The specified path is not valid");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    //lägg in era options här för max login attempts, olika password requirements etc.
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
   {
       policy.AllowAnyOrigin();
       policy.AllowAnyHeader();
       policy.AllowAnyMethod();
   });
});
//Adding admin role and admin user

//Den här måste vara utkommenterad när man skapar database för första gången.

using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
{
    var signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    RoleManager createRoleManager = new RoleManager(signInManager, roleManager);
    createRoleManager.InitialAdminAccount();

    //lade till så att det skapas en member också när man startar appen, samma logik som för admin account. kolla Rolemanager för credentials albin //Emil
    createRoleManager.InitialMemberAccount();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapControllers();

app.UseCors("AllowAll");

//samis middleware
//app.UseMiddleware<CustomMiddleware>(); // Custom middleware
app.Run();

