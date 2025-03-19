using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context; //Bunu IoC konteynırdan alıyorum. Ve böylece bunun üzerinde gerekli işlemleri gerçekleştireceğiz. Yani ReadRepository i IoC konteynıra gönderdiğim zaman bana context i de getirebilecek

        /*
         //Bir sınıf, bir interface kullanıyorsa eğer aynen abstract class'lar da ki abstract elemanlarda olduğu gibi içerisindeki member'ların uygulanmasını/tanımlanmasını zorunlu kılar. Yani interface, bir sınıfa içerisinde tanımlanacak member'ların kendi içerisindeki imzaların olacağının taahhüdünü verir! İşte bu taahhüdden interface'in can-do ilişkisi/davranışı sergilediğini gözlemlemekteyiz.
        //interface, bir class içerisinde tanımlanacak member'ları zoraki uygulattırdığı için member içerisinde hangi davranışların, işlevlerin yani yeteneklerin olabileceğini özetlemektedir.
        //Yani bir interface'e bakılıdığında, o interface'i uygulayan sınıfların neler yapabileceğini(can-do), hangi yeteneklere sahip olabileceği hakkında rahatlıkla yorumda bulunabilmektedir.
        //İşte bu durumda interface'lerin yapısal olarak nesnelerle can-do ilişkisi kurduğunu göstermektedir.
        //interface in içindeki imzalar implemente edildiği sınıflara zoraki uygulattırıldığından interface bir sözleşmedir
         */

        public ReadRepository(ETicaretAPIDbContext context) // Bu constructor dur
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>(); // _context'ten sonra tüm entitylerin gelmesini istiyorsam, bunun için .Set<T>(); yapmam yeterli olacaktır. Generic türü de T olmalıdır bu arada

        public IQueryable<T> GetAll() => Table; //Neden? çünkü Table DbSet tir, DbSet ise IQuaryable'dır. Ve generic olduğundan bu şekilde geriye döndürülebilecektir

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method); //Async olduğundan dolayı await oluyor.

        public Task<T> GetByIdAsync(string id) // İlk etapta elimde bir id olmadığı için kıyaslayabileceğim bir değer yok. GetById gibi değersel yapılarda generic çalışmak istiyorsak o değerleri temsil eden bir arayüz ya da sınıf tasarlamamız gerekiyor. Bu sebeple IRepository'de class yerine BaseEntity yazarak BaseNetity'leri işaretliyoruz id olarak değer alabilmesi için default olaraktan. Bu yönteme marker pattern denir.
        => Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));//BaseEntity'den alıyor Id yi ve BaseEntity'deki Id Guid türünde olduğundan Guid trünü parse ederek string türüyle matchleyecektir.
        //Id bazlı çalışmaklarda reflectiona girip maliyetli çalışmalar yapmaktansa BaeENtity'i markerlayıp oradaki değerleri kullanmamız bizim için daha kolay olacaktır

    }
}
