namespace Wed_16._30_MD_G2_Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();

        // Add services to the container.
        builder.Services.AddApplicationInsightsTelemetry(options =>
        {
            options.EnableAdaptiveSampling = false; // Disable sampling to capture all logs
        });
        
        builder.Logging.AddApplicationInsights(
                configureTelemetryConfiguration: (config) => 
                {
                    config.DisableTelemetry = false;
                },
                configureApplicationInsightsLoggerOptions: (options) =>
                {
                    options.IncludeScopes = true;
                    options.TrackExceptionsAsExceptionTelemetry = true;
                });
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
