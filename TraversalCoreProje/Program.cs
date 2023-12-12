using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>()
	.AddErrorDescriber<CustomIdentityValidator>()
	.AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)
	.AddEntityFrameworkStores<Context>();

builder.Services.AddHttpClient();


builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.CustomerValidator();

builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

//builder.Services.AddMediatR(typeof(Program).Assembly);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));



builder.Services.AddLogging(x =>
{
	x.ClearProviders();
	x.SetMinimumLevel(LogLevel.Debug);
	x.AddDebug();
});

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();


builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Login/SignIn/";

});






var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

var supportedCulture = new[] { "en", "fr", "es", "gr", "tr","de" };
var localiationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCulture[0]).AddSupportedCultures(supportedCulture).AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(localiationOptions);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

//app.UseEndpoints(endpoints =>
//{
//	endpoints.MapControllerRoute(
//	  name: "areas",
//	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//	);
//});

app.Run();
