using iTextSample.Services;
using iTextSample.Services.Helper;
using iTextSample.Services.Interface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
	c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo
		{
			Title = "iText Samples",
			Version = "v1",
			Description = "<strong>Author</strong>: Warakorn Kidkumnuan.<br/>This is iText sample functions for training in ITSC, Chiang Mai University. This project use iText7 and API in .NET 6."
		});
		// Set the comments path for the Swagger JSON and UI.
		var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
		var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
		c.IncludeXmlComments(xmlPath);
	}
	);

// Add dependency injection
builder.Services.AddScoped<ILocalFont, LocalFont>();
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IPdfService, PdfService>();
// ---------------------------------------

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

app.UseStaticFiles();

app.Run();