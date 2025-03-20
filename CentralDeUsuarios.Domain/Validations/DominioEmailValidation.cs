using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Domain.Validations
{
    public class DominioEmailValidation
    {
        public bool Validar(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return false;

            var dominio = email.Split('@').Last();

            try
            {
                // Obtém os registros MX (Mail Exchange) do domínio
                var hostEntry = Dns.GetHostEntry(dominio);
                return hostEntry.AddressList.Any(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            }
            catch
            {
                return false; // Domínio inválido ou não existe
            }
        }
    }
}
