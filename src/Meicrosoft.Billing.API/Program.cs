using Meicrosoft.Billing.Application.Profiles;
using Meicrosoft.Billing.Infra.CrossCutting.IoC;
using System.Text.Json.Serialization;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDatabaseInjection(builder.Configuration);
        builder.Services.AddMediatorInjection();
        builder.Services.AddRepositoryInjection();
        builder.Services.AddAutoMapper(typeof(OrderProfile));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}