using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Domain.Core
{
    /// <summary>
    /// Interface para abstração de repositórios
    /// </summary>
    /// <typeparam name="TEntity">Defini o tipo da entidade</typeparam>
    /// <typeparam name="TKey">Define o tipo do ID da entidade</typeparam>
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);

        List<TEntity> GetAll();
        TEntity GetById(TKey id);
    }
}
