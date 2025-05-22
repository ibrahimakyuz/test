using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business;
using WebAPI.DataAccess;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
////TODO: ��erik Pazarl��� i�in konfig�rasyon yapaca��z.
//builder.Services.AddControllers(config => 
//{
//    config.RespectBrowserAcceptHeader = true; //TODO: Acceptable olanlar� d�nd�r.
//    config.ReturnHttpNotAcceptable = true; //TODO: Bizim kabul edemedi�imiz bir i�erik varsa 406 d�nd�r.
//}).AddNewtonsoftJson(); //TODO: NewtonsoftJson paketini kullanabilmek i�in gerekli ayarlar� yapal�m.

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddScoped<WebAPI.Business.IKitapService, KitapService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IOduncService, OduncService>();



builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            ),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization();



var app = builder.Build();
app.UseCors("AllowAngularClient");
app.UseAuthentication();
app.UseAuthorization();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
