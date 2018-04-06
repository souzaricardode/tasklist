using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TaskList.Model.Model;
using TaskList.Model.Resources;

namespace TaskList.Model.Excecoes
{
    [Serializable]
    public class ValidacaoException : Exception
    {
        private readonly List<ValidationFailure> erros;

        public ValidacaoException()
        {
            throw new ArgumentException(ResourceExcecoes.NENHUM_ERRO_ASSOCIADO);
        }

        public ValidacaoException(string message) : base(message)
        {
            throw new ArgumentException(ResourceExcecoes.NENHUM_ERRO_ASSOCIADO);
        }

        public ValidacaoException(string message, IEnumerable<ValidationFailure> erros) :
            base(message)
        {
            if (!erros.Any())
                throw new ArgumentException(ResourceExcecoes.NENHUM_ERRO_ASSOCIADO);

            this.erros = new List<ValidationFailure>();
            this.erros.AddRange(erros);
        }

        public ValidacaoException(string message, ValidationFailure erros)
            : base(message)
        {
            if (erros != null)
                throw new ArgumentException(ResourceExcecoes.NENHUM_ERRO_ASSOCIADO);

            this.erros = new List<ValidationFailure>();
            this.erros.Add(erros);
        }

        public ValidacaoException(string message, Exception innerException) : base(message, innerException)
        {
            throw new ArgumentException(ResourceExcecoes.NENHUM_ERRO_ASSOCIADO);
        }

        protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            throw new ArgumentException(ResourceExcecoes.NENHUM_ERRO_ASSOCIADO);
        }

        public IEnumerable<Erro> ObterErros()
        {
            var erros = new List<Erro>();
            this.erros?.ForEach(falha =>
                erros.Add(new Erro
                {
                    Campo = falha.PropertyName,
                    Mensagem = falha.ErrorMessage
                })
            );

            return erros;
        }

        public override string ToString()
        {
            var erros = new StringBuilder();
            this.erros?.ForEach(falha => erros.Append($"{falha.PropertyName}: {falha.ErrorMessage}"));
            return erros.ToString();
        }
    }
}

