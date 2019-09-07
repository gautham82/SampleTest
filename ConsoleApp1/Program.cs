using System;
using Microsoft.Extensions.DependencyInjection;
using ReferenceIntegration;

namespace ConsoleApp1
{
    class Program
    {
        private static IServiceProvider serviceProvider = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SetUpDependencyInjection();

            CallRegionFinder();
        }

        private static void SetUpDependencyInjection()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IReadOnlyRepository<Coverage>, CoverageRepository>();

            serviceCollection.AddScoped<IReadOnlyRepository<Region>, RegionRepository>();
            
            //cache implement
            serviceCollection.AddScoped<IReadOnlyRepository<Region>, RegionRepository>();

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void CallRegionFinder()
        {
            //is this correct?
            var serviceRegion = serviceProvider.GetService<IReadOnlyRepository<Region>>();

            var r = serviceRegion.Find("1");
        }
    }
}
