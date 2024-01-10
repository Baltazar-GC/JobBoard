
using backend.Contexts;
using backend.Entities;
using backend.Repositories.Implementations;
using backend.Repositories.Interfaces;
using backend.Services.Implementations;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ApplicationUtnContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("BolsaDeTrabajoApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "..."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BolsaDeTrabajoApiBearerAuth" }
                }, new List<string>() }
    });
});


builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<ApplicationUtnContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IJwtGeneratorService, JwtGeneratorService>();
builder.Services.AddScoped<IDegreeService, DegreeService>();
builder.Services.AddScoped<IDegreeRepository, DegreeRepository>();
builder.Services.AddScoped<ITechnologyLevelRepository, TechnologyLevelRepository>();
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IBusinessInformationRepository, BusinessInformationRepository>();
builder.Services.AddScoped<IBusinessInformationService, BusinessInformationService>();
builder.Services.AddScoped<IBusinessContactRepository, BusinessContactRepository>();
builder.Services.AddScoped<IBusinessContactService, BusinessContactService>();
builder.Services.AddScoped<IStudentPersonalInformationRepository, StudentPersonalInformationRepository>();
builder.Services.AddScoped<IStudentPersonalInformationService, StudentPersonalInformationService>();
builder.Services.AddScoped<IStudentCollegeInformationRepository, StudentCollegeInformationRepository>();
builder.Services.AddScoped<IStudentCollegeInformationService, StudentCollegeInformationService>();
builder.Services.AddScoped<IInternshipRepository, InternshipRepository>();
builder.Services.AddScoped<IInternshipService, InternshipService>();
builder.Services.AddScoped<IHiredEmployeeOfferRepository, HiredEmployeeOfferRepository>();
builder.Services.AddScoped<IHiredEmployeeOfferService, HiredEmployeeOfferService>();
builder.Services.AddScoped<IOtherSkillsRepository, OtherSkillsRepository>();
builder.Services.AddScoped<IOtherSkillsService, OtherSkillsService>();
builder.Services.AddScoped<IApproveEmployersRepository, ApproveEmployersRepository>();
builder.Services.AddScoped<IStudentExtraDataRepository, StudentExtraDataRepository>();
builder.Services.AddScoped<IStudentExtraDataService, StudentExtraDataService>();
builder.Services.AddScoped<IApplicationInternshipRepository, ApplicationInternshipRepository>();
builder.Services.AddScoped<IApplicationInternshipService, ApplicationInternshipService>();
builder.Services.AddScoped<IApplicationHiredRepository, ApplicationHiredRepository>();
builder.Services.AddScoped<IApplicationHiredService, ApplicationHiredService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<MailService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
