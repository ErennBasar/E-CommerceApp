using System.Linq.Expressions;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Application.Repositories;

// Bu işlemleri ORM'de yapıyor ama bu şekilde olunce customize edilebiliyor
public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    
    //bir şart olsun bu şartı sağlayan birden fazla veri getirilsin
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); // bu özel tanımlı fonksiyona verilen şart ifadesi doğru olan datalar sorgulanıp getirilecek

    // FisrtOrDefault'un asenkron fonksiyonunu kullanacak
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //şartı sağlayan tek bir veri getirilsin
    
    Task<T> GetByIdAsync(string id, bool tracking = true); //id ile veri getirilsin 

}