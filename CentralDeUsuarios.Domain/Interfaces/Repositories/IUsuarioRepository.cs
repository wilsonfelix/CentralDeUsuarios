using CentralDeUsuarios.Domain.Core;
using CentralDeUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        /// <summary>
        /// Interface de repositório de usuário
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Usuario GetByEmail(string email);
        //Task Adicionar(Usuario usuario);
        //Task Atualizar(Usuario usuario);
        //Task<Usuario> ObterPorId(Guid id);
        //Task<IEnumerable<Usuario>> ObterTodos();
        //Task Remover(Guid id);
    }
}
