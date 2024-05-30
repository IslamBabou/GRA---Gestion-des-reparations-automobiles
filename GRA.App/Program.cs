using Blazored.LocalStorage;
using GRA.App;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor.Popups;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using GRA.App.Handlers;
using GRA.App.Services.Contracts;
using GRA.App.Services.Implementations;
using Blazored.SessionStorage;
using Syncfusion.Blazor.Grids;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXpcdnRdRGJcV0V2WEo="]);
bool isValid = SyncfusionLicenseProvider.ValidateLicense(Platform.Blazor);

builder.Services.AddTransient<AuthHandler>();
builder.Services.AddHttpClient("ServerApi")
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? ""))
                .AddHttpMessageHandler<AuthHandler>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IAppointmentService, AppointmentService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IVehicleService, VehicleService>();
builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<IRepairService, RepairService>();
builder.Services.AddSingleton<IReportService, ReportService>();
builder.Services.AddSingleton<IStockService, StockService>();

builder.Services.AddBlazoredSessionStorageAsSingleton();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
await app.RunAsync();