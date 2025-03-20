using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Domain.Core
{
    /// <summary>
    /// Classe base para exceções de domínio
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string errorMessage)
            : base(errorMessage)
        { 
            
        }

        /// <summary>
        /// Método para lançar exceção de domínio
        /// </summary>
        /// <param name="hasError">Condição para disparar o erro</param>
        /// <param name="errorMessage">Mensagem de erro</param>
        
        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainException(errorMessage);
        }
        
    }
}
