using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    //Her zaman Visual Studio Package Manager COnsole üzerinden migration yapamayabiliriz. Bazen dotnet CLI üzerinden Class Library odaklı yapmamız gerekebilir. Bunun için ekstradan burayı yazmamız gerekir.
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
            //Şimdi dbContextOptionsBuilder adında bir nesne oluşturduk. Bu DbContextOptionsBuilder nesnesi hangi sunucuya bağlanacaksa onun bağlantı fonksiyonunu barındıracaktır dolayısıyla Postgresql olanını ekliyorum:
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
