using PollPulse.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureCors();
builder.Services.ConfigureSqlSqerverContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureUnitOfWorkRepository();
builder.Services.ConfigureSendGrid(builder.Configuration);


builder.Services.AddAutoMapper(typeof(PollPulse.CommandsAndQueries.Startup).Assembly);
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(PollPulse.CommandsAndQueries.Startup).Assembly));
builder.Services.AddSendGridConfiguration(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PollPulse.Presentation.Startup).Assembly);

var app = builder.Build();


app.ConfigureExceptionHandling();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
