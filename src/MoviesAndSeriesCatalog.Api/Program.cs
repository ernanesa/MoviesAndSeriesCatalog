using Scalar.AspNetCore;
using MoviesAndSeriesCatalog.Api.Extensions;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String 'DefaultConnection' not found.");

builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
        {
            options.Title = "Movies and Series Catalog";
            options.Theme = ScalarTheme.DeepSpace;
        });
}

app.UseHttpsRedirection();

app.Run();
