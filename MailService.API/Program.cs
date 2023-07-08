using MailService.API.Abstraction;
using MailService.API.MailService.BL;
using MailService.API.MailService.DAL.Data;
using MailService.API.MailService.DAL.Repositories;
using MailService.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));
var emailSetting = builder.Configuration.GetSection(nameof(EmailSenderSettings)).Get<EmailSenderSettings>() ?? new EmailSenderSettings();
builder.Services.AddSingleton(new SmtpClient
{
    Host = emailSetting.Server,
    Port = emailSetting.Port,
    EnableSsl = emailSetting.EnableSsl,
    UseDefaultCredentials = false,
    DeliveryMethod = SmtpDeliveryMethod.Network,
    Credentials = new NetworkCredential(emailSetting.UserName, emailSetting.Password)
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
