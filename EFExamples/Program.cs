using EFExample.Services;
using EFExamples.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting!");
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().PerformOperations();
            Console.WriteLine("Ending!");
        }



        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                .Build();


            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddTransient<ICarOwnersService, CarOwnersService>();
            serviceCollection.AddDbContext<CarOwnersContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddTransient<App>();
        }
    }
}
