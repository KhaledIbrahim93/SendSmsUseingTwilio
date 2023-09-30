using SendSMS.Dtos;
using SendSMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TwilloSetting>(builder.Configuration.GetSection("TwilloSetting"));
TwilloSetting setting = new();
builder.Configuration.GetRequiredSection("TwilloSetting").Bind(setting);
builder.Services.AddTransient<ISendSMS,SendSMS.Services.SendSMS>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
