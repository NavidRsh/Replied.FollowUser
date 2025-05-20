using Replied.FollowUser.Application;
using Replied.FollowUser.Infrastructure.InMemory;
using FluentValidation;
using Replied.FollowUser.Web.ViewModels;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddApplicationServices();
builder.Services.AddnMemoryServices();

builder.Services.AddValidatorsFromAssemblyContaining<SendFollowRequestVMValidator>();

var app = builder.Build();

EnsureDbIsCreated(app);

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


void EnsureDbIsCreated(WebApplication webApplication)
{

    using (var scope = webApplication.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        
        context.Database.EnsureCreated();        
    }

}