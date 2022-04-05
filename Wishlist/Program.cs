using Microsoft.EntityFrameworkCore;
using Wishlist.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CardDB>(opt => opt.UseInMemoryDatabase("CardList"));

var app = builder.Build();


if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();