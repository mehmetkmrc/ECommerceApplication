using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Context
{
    //Bir db context nesnesi olacak EntityFramework ORMsini kullandığımızdan dolayı
    public class ETicaretAPIDbContext : DbContext
    {
        //IoC konteyner a Db context i vereceğiz. Oradan talep ederken belirli configürasonlarda opsionlarda gelmesini istiyorsak bu ayarların constructor da bildirilmesi gerekiyor
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        //Veritabanını temsil eden bu db context te sanki bu formatta bir tablo olacağını bildirdim
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        //Bunları bildirince bir adet veritabanım olacak, şu isimlerde uygun tablolar olacak demiş oldum

    }
    //Şimdi bunu IoC konteyner a eklemem lazım ki API üzerinden erişebilryim
}
