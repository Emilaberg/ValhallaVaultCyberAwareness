using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Components;
using ValhallaVaultCyberAwareness.Components.Account;
using ValhallaVaultCyberAwareness.Components.Middleware;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Repositories;
//using static ValhallaVaultCyberAwareness.Components.Pages.Home;


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
//builder.Services.AddScoped<MyProgressService>();
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

//using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
//{
//    var signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
//    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//    new RoleManager(signInManager, roleManager).InitialAdminAccount();
//}

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

app.UseMiddleware<CustomMiddleware>(); // Custom middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


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

app.Run();

