using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository //ICustomerReadRepository interface i ile CustomerReadRepository conrcrete nesnesinin abstractionudur. Yani ben DI(Dependency Injection) ile CustomerReadRepository ı talep ederken ICustomerReadRepository ile talep edeceğim. Ve ayrıca burada ICustomerReadRepository, CustomerReadRepository nin imzası/doğrulayıcısı olurken  ReadRepository<Customer> nin de uygulayıcısı oluyor. Kilit anahtar sistemi gibi
    {
        public CustomerReadRepository(ETicaretAPIDbContext context) : base(context) //ETicaretAPIDbContext context'ın nesnesi IoC konteynırdan gelirken base e buradaki context i göndermek zorundasın
        {
        }
    }
}
