using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PapaPizza.Infraestructure.Repository.Implementation;
using PapaPizza.Infraestructure.Repository.Interface;
using PapaPizza.Presentation;

internal class Program
{
    private static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder.Services);
        var host = builder.Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        IIngredientRepository ingredientRepository = provider.GetService<IIngredientRepository>();
        IRecipeRepository recipeRepository = provider.GetService<IRecipeRepository>();
        IRecipeIngredientRepository recipeIngredientRepository = provider.GetService<IRecipeIngredientRepository>();

        var app = new PapaPizaApp(recipeIngredientRepository,ingredientRepository,recipeRepository);

        app.RunApp();

        Console.WriteLine("  _______   _                 _ \r\n |__   __| | |               | |\r\n    | | ___| |__   __ _ _   _| |\r\n    | |/ __| '_ \\ / _` | | | | |\r\n    | | (__| | | | (_| | |_| |_|\r\n    |_|\\___|_| |_|\\__,_|\\__,_(_)\r\n                                \r\n                                ");
    }
     
    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        
        serviceCollection.AddScoped<IIngredientRepository, IngredientRepository>()
                        .AddScoped<IRecipeRepository, RecipeRepository>()
                        .AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();

    }
}