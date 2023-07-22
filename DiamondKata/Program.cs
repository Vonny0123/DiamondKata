using DiamondKata.Model;
using DiamondKata.Program;
using DiamondKata.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IAsciiArtBuilder<char>, DiamondBuilder>();
builder.Services.AddScoped<IAsciiArtBuilder<DiamondLineData>, DiamondLineBuilder>();
builder.Services.AddScoped<IConverter<char, int>, CharacterIndexConverter>();
builder.Services.AddScoped<IConsoleInteractionProvider, ConsoleInteractionProvider>();
builder.Services.AddScoped<IUserInputManager<char>, UserInputManager>();

using IHost host = builder.Build();

CreateDiamond(host.Services);

await host.RunAsync();

static void CreateDiamond(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    // Use dependency injection to get the required objects
    var diamondBuilder = provider.GetRequiredService<IAsciiArtBuilder<char>>();
    var consoleInteractionProvider = provider.GetRequiredService<IConsoleInteractionProvider>();
    var userInputManager = provider.GetRequiredService<IUserInputManager<char>>();

    char userInput = userInputManager.GetUserInput();

    try
    {
        var diamond = diamondBuilder.Build(userInput);
        Console.WriteLine(diamond);
    }
    catch (ArgumentException e)
    {
        consoleInteractionProvider.WriteError("An error occurred. Please ensure you enter only a single upper-case letter of the alphabet.");
        consoleInteractionProvider.WriteError($"Inner Exception:{Environment.NewLine}{e.Message}");
        Environment.Exit(1);
    }

}
