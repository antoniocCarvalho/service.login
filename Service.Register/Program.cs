using Microsoft.EntityFrameworkCore;
using Service.Register.Application.Abstractions.Features;
using Service.Register.Application.Features;
using Service.Register.Infra.Data;
using Service.Register.Infra.Data.Features;

var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados com a string de conexão definida no appsettings.json
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o serviço IUsersService no contêiner de DI
builder.Services.AddScoped<IUsersService, UserService>();

// Registro do repositório no contêiner DI
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()   // Permite qualquer origem
               .AllowAnyMethod()   // Permite todos os métodos (GET, POST, etc.)
               .AllowAnyHeader();  // Permite todos os cabeçalhos
    });
});

// Adiciona suporte para controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // O valor padrão do HSTS é 30 dias.
}

app.UseHttpsRedirection();

app.UseRouting();


// Aplica a política de CORS
app.UseCors("AllowAllOrigins");

// Habilita o uso de endpoints para os controladores
app.UseEndpoints(endpoints =>
{
    ControllerActionEndpointConventionBuilder controllerActionEndpointConventionBuilder = endpoints.MapControllers();
});




using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<UserContext>();
    context.Database.Migrate();
}



// Rota básica para verificar se a API está rodando
app.MapGet("/", () => "API is running.");

app.Run();
