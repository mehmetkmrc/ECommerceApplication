using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity//Bu genel bir Repository interface i olup, base yapılı tüm repository'leri içerecek şekilde olmalı. Tabi ben burada evrensel olarak tüm entity'leri kullanmak istediğim için(Sadece product, order vs değil, tüm hepsini) generic ekleyip bu generic yapıya T parametresi atıyorum.
    {
        DbSet<T> Table { get; } //Mesela burada evrensel olması için T parametresini buradaki generic e de ekledik. Ve bu T parametrelerinin karşılık geldiği kısımlardan birine Table de. Burada set işlemi yok çünkü burada sadece Table adlı verisetini getirmek için çalışıyoruz. Üzerinde bir değişiklik yapmıyorlar.
    }
}
