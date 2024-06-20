using ECommerce.Data;
using ECommerce.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllersWithViews();

// Configura o DbContext para usar SQL Server
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                         b => b.MigrationsAssembly("ECommerce.Web")));

// Configuração do Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ECommerceDbContext>()
    .AddDefaultTokenProviders();

// Adiciona os serviços ao contêiner de injeção de dependência
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CartService>(); // Adicione esta linha

var app = builder.Build();

// Cria as roles se elas não existirem
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roleNames = { "Admin", "User" };
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            // Cria a role
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Cria um usuário admin de exemplo (opcional)
    var adminUser = new IdentityUser
    {
        UserName = "admin",
        Email = "admin@example.com",
        EmailConfirmed = true,
    };
    var userPassword = "Admin@123";
    var user = await userManager.FindByEmailAsync(adminUser.Email);

    if (user == null)
    {
        var createAdminUser = await userManager.CreateAsync(adminUser, userPassword);
        if (createAdminUser.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

// Configura o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Rotas padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
