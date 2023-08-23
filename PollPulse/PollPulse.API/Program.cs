using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using PollPulse.API.Extensions;
using PollPulse.Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureCors();
builder.Services.ConfigureSqlSqerverContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureUnitOfWorkRepository();
builder.Services.ConfigureAuthentication();


builder.Services.AddAutoMapper(typeof(PollPulse.Application.Startup).Assembly);
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(PollPulse.Application.Startup).Assembly));
builder.Services.AddSmtpConfiguration();
builder.Services.AddValidatorsFromAssembly(typeof(PollPulse.Validation.Startup).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddJwtConfiguration();
builder.Services.AddJwtBearerConfiguration();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
})
    .AddApplicationPart(typeof(PollPulse.Presentation.Startup).Assembly);

builder.Services.RegisterExternalServicesIntoDIContainer();

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

