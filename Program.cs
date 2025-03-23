using WebAppCoreProduct.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Настройка конвейера запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();