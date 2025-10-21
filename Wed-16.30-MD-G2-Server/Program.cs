namespace Wed_16._30_MD_G2_Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplicationInsightsTelemetry("InstrumentationKey=f3d57649-06a5-4957-87dd-db0d6fd61d03;IngestionEndpoint=https://australiaeast-1.in.applicationinsights.azure.com/");
        
        builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));


        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Logging.AddApplicationInsights(
                configureTelemetryConfiguration: (config) => { },
                configureApplicationInsightsLoggerOptions: (options) =>
                {
                    options.IncludeScopes = true;
                    options.TrackExceptionsAsExceptionTelemetry = true;
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
    }
}
