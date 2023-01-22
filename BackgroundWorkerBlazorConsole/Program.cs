using BackgroundWorkerBlazorConsole;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHostedService<MyBackgroundService1>();
builder.Services.AddHostedService<MyBackgroundService2>();
builder.Services.AddHostedService<MyBackgroundService3>();
builder.Logging.ClearProviders();

var state = new State();
builder.Logging.AddProvider(new MyLogProvider(state));
builder.Services.AddSingleton(state);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
