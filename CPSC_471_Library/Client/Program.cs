global using CPSC_471_Library.Client.Services.BookService;
global using CPSC_471_Library.Client.Services.StaffService;
global using CPSC_471_Library.Client.Services.LibraryEventService;
global using CPSC_471_Library.Client.Services.LibraryService;
global using CPSC_471_Library.Client.Services.ContactFormService;
global using CPSC_471_Library.Client.Services.CdvdService;
global using CPSC_471_Library.Shared;
using CPSC_471_Library.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ILibraryEventService, LibraryEventService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IContactFormService, ContactFormService>();
builder.Services.AddScoped<ICdvdService, CdvdService>();

await builder.Build().RunAsync();
