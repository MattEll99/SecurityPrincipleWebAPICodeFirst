using Microsoft.EntityFrameworkCore;
using SecurityPrincipleWebAPICodeFirst.Data;
using SecurityPrincipleWebAPICodeFirst.Interfaces;
using SecurityPrincipleWebAPICodeFirst.Repository;
using static SecurityPrincipleWebAPICodeFirst.Data.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//AutoMapper && DTOs
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Repository Pattern.
builder.Services.AddScoped<ISecurityPrincipleRepository, SecurityPrincipleRepository>();
builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
builder.Services.AddScoped<IvGroupMemberRepository, vGroupMembersRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Both Connections strings
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SourceDbDefaultConnection"));
});
builder.Services.AddDbContext<TDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TargetDBDefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
