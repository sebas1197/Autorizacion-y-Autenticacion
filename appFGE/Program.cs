using appFGE.Connections;
using appFGE.Repository;
using appFGE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = builder.Configuration["AllowedHosts"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoginRepository, LoginServices>();
builder.Services.AddScoped<IPermissionRepository, PermissionService>();
builder.Services.AddScoped<IRoleRepository, RoleService>();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<ISessionRepository, SessionService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSql"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
