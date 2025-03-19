using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(); //Db deki tüm verileri getirir.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);   //SQL deki gibi verileri filtreleyerek çoklu veri döndürebilir verilerin filtrelenmesiyle.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); //Tek bir veri döner ancak aynı verinin birden fazla olması durumunda hata verir. FirstOrDefault'un asenkron fonksiyonunu kullanacak
        Task<T> GetByIdAsync(string id);// Task olarak döndürülmesini sitediğimden dolayı Task<T> kullandım.


    }
}
