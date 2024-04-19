using Dapper;
using golum.DataAccessLayer;
using golum.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDBService, DbService>();
builder.Services.AddScoped<ILogin, Login>();


var app = builder.Build();

// Dapper Propouse
DefaultTypeMap.MatchNamesWithUnderscores = true;


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
