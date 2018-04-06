using TaskList.BLL.Test;
using TaskList.Model.Excecoes;
using TaskList.Model.Model;
using TaskList.Model.Resources;
using Xunit;
using FluentAssertions;

namespace TaskList.BLL.Tests
{
    public class AtualizarTarefaTest : NegocioBaseTest
    {
        private readonly TarefaNegocio negocio;

        public AtualizarTarefaTest()
        {
            negocio = mocker.Resolve<TarefaNegocio>();
        }

        private Tarefa GerarEntidade()
        {
            var diretoria = new Tarefa
            {
                Id = 1,
                Descricao = "Tarefa 1",
            };
            return diretoria;
        }

        [Fact]
        public void AtualizarSucesso()
        {
            var entidade = GerarEntidade();
            negocio
                .Invoking(x => x.Atualizar(entidade))
                .Should()
                .NotThrow<ValidacaoException>();
        }

        [Fact]
        public void AtualizarComNomeVazio()
        {
            var entidade = GerarEntidade();
            entidade.Descricao = string.Empty;
            negocio
                .Invoking(x => x.Atualizar(entidade))
                .Should()
                .NotThrow<ValidacaoException>();
        }

        [Fact]
        public void AtualizarComNomeNulo()
        {
            var entidade = GerarEntidade();
            entidade.Descricao = null;
            negocio
                .Invoking(x => x.Atualizar(entidade))
                .Should()
                .NotThrow<ValidacaoException>();
        }

        [Fact]
        public void AtualizarComDescricaocimaMaximoCaracteres()
        {
            var entidade = GerarEntidade();
             entidade.Descricao = this.GerarStringMaximoCaracteres(ColumnLength.Descricao + 1);
            negocio
                .Invoking(x => x.Atualizar(entidade))
                .Should()
                .Throw<ValidacaoException>()
                .WithMessage(ResourceValidacoes.CAMPOS_INVALIDOS)
                .And
                .ObterErros()
                .Should()
                .Contain(erro => erro.Mensagem == string.Format(ResourceValidacoes.MAXIMO_CARACTERES, new object[] { ResourceCampos.TAREFA_DESCRICAO, ColumnLength.Descricao }));
        }
    }
}
