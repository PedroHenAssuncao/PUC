using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PapaPizza.Infraestructure.Repository.Implementation;
using PapaPizza.Infraestructure.Repository.Interface;

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

        Console.WriteLine("Hello, World!");
    }
     
    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        
        serviceCollection.AddScoped<IIngredientRepository, IngredientRepository>()
                        .AddScoped<IRecipeRepository, RecipeRepository>()
                        .AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();

    }
}