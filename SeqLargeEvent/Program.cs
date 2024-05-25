// See https://aka.ms/new-console-template for more information
using Serilog;
using System.Text;

Console.WriteLine("Hello, World!");

// Configure Serilog logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5342",eventBodyLimitBytes:500200)
    .CreateLogger();

// Write some log messages
Log.Information("Application starting...");
Log.Warning("This is a warning message.");
Log.Error(new Exception("Something went wrong!"), "An error occurred.");



// Generate large log message (replace with your desired content)
var largeMessage = GenerateLargeMessage(270 * 1024);  // Adjust size as needed (here, 270kb)

// Write log message
Log.Information("Large log message: {LargeMessage}", largeMessage);


// Important: Close the logger to flush any batched events
Log.CloseAndFlush();

Console.WriteLine("Press any key to exit...");
Console.ReadKey(true);


 static string GenerateLargeMessage(int size)
{
    var builder = new StringBuilder(size);
    for (int i = 0; i < size; i++)
    {
        builder.Append('x');  // Replace with your preferred character
    }
    return builder.ToString();
}
