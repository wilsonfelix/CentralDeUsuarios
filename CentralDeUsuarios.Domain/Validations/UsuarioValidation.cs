using CentralDeUsuarios.Domain.Entities;
using CentralDeUsuarios.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CentralDeUsuarios.Domain.Validations
{
    /// <summary>
    /// Classe para validação de entidade de usuário
    /// </summary>
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        private readonly DominioEmailValidation _dominioEmailValidation;

        public UsuarioValidation()
        {
            _dominioEmailValidation = new DominioEmailValidation();

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório!");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório!")
                .Length(8, 150).WithMessage("Nome deve conter entre 8 a 150 caracteres!")
                .Matches(@"^[A-Za-zÀ-ÿ' ]+$").WithMessage("Nome contém caracteres inválidos!")
                .Must(nome => !Regex.IsMatch(nome, @"\s{2,}")).WithMessage("Nome não pode conter espaços consecutivos!");

            _ = RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório!")
                .EmailAddress().WithMessage("Email inválido!")
                .Must(email => _dominioEmailValidation.Validar(email)).WithMessage("Domínio de email inválido!");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória!")
                .Length(8, 20).WithMessage("Senha deve conter entre 8 a 20 caracteres!")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");

            RuleFor(x => x.ConfirmacaoSenha)
                .NotEmpty().WithMessage("Confirmação de senha é obrigatória!")
                .Equal(x => x.Senha).WithMessage("As senhas não coincidem!");
        }
    }
}
