using ElmahCore;
using ElmahCore.DemoCore6;
using ElmahCore.Mvc;
using ElmahCore.Mvc.Observers;
using ElmahCore.Observer.Mssql;
using BuilderHelper = ElmahCore.WebUi.BuilderHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddElmah<XmlFileErrorLog>(options =>
{
    options.LogPath = "~/log";
    options.Notifiers.Add(new MyNotifier());
    options.Filters.Add(new CmsErrorLogFilter());
});

BuilderHelper.AddElmahWebUi<XmlFileErrorLog>(builder.Services, options =>
{
    options.LogPath = "~/log";
});

// Add any diagnostic observers.
builder.Services.AddSingleton<IElmahDiagnosticObserver, ElmahDiagnosticSqlObserver>();

var app = builder.Build();

var svcTest = app.Services.GetServices<IElmahDiagnosticObserver>();

// Configure the HTTP request pipeline.
app.UseElmahExceptionPage();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

BuilderHelper.UseElmah(app);

app.MapRazorPages();

app.Run();