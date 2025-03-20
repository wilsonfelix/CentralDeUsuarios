using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CentralDeUsuarios.Domain.Core
{
    /// <summary>
    /// Interface para definição de tipos de entidade
    /// </summary>
    /// <typeparam name="TKey">Tipo de ID da entidade</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Retorna o resumo da validação da entidade
        /// </summary>
        ValidationResult Validate { get; }
    }
}
