using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using PollPulse.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureCors();
builder.Services.ConfigureSqlSqerverContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureUnitOfWorkRepository();

builder.Services.AddAutoMapper(typeof(PollPulse.CommandsAndQueries.Startup).Assembly);
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(PollPulse.CommandsAndQueries.Startup).Assembly));
builder.Services.AddSmtpConfiguration(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
})
    .AddApplicationPart(typeof(PollPulse.Presentation.Startup).Assembly);
    

var app = builder.Build();


app.ConfigureExceptionHandling();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
        new ServiceCollection()
        .AddLogging()
        .AddMvc()
        .AddNewtonsoftJson()
        .Services
        .BuildServiceProvider()
        .GetRequiredService<IOptions<MvcOptions>>()
         .Value
        .InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>()
        .First();

