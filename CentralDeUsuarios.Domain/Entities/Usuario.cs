﻿using CentralDeUsuarios.Domain.Core;
using CentralDeUsuarios.Domain.Validations;
using CentralDeUsuarios.Domain.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade de domínio para usuários
    /// </summary>
    public class Usuario : IEntity<Guid>
    {
        
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ConfirmacaoSenha { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public ValidationResult Validate => new UsuarioValidation().Validate(this);
    }
}
