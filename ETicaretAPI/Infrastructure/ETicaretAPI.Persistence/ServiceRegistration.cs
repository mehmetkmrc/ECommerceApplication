using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Concrete;
using ETicaretAPI.Persistence.Context;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        //IoC konteyner ımın üstüne bir extension fonksiyon sağlıyor, bu fonksiyon üzerinden datalarımı direkt olarak gönderebiliyorum
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //Şimdi burada hangi server a veritabanını migrate edeceksem onu yazıyorum. Postgresql kullandığım için bu şekilde olacak:
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

            //Singleton sayesinde tek bir instance üzerinden globale erişebilirsin
            //Burada IProductService referansına karşılık ProductService e erişilebilir şimdi
            // services.AddSingleton<IProductService, ProductService>();
            //Şimdi bu service in Presentation katmanındaki IoC konteynerın bulunduğu asp.netcore tarafından çağrılması gerekiyor
        }
    }
}
