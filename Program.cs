var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Paperless_rfa.interfaces.IUserAccess, Paperless_rfa.DataAccess.UserAccess>();
builder.Services.AddScoped<Paperless_rfa.interfaces.IEmployeeAcess, Paperless_rfa.DataAccess.EmployeeAccess>();
builder.Services.AddScoped<Paperless_rfa.interfaces.IDepartementAccess, Paperless_rfa.DataAccess.DepartementAccess>();
builder.Services.AddScoped<Paperless_rfa.interfaces.ISupplierAccess, Paperless_rfa.DataAccess.SupplierAccess>();
builder.Services.AddScoped<Paperless_rfa.interfaces.IItemAccess, Paperless_rfa.DataAccess.ItemAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
